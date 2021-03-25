using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameTree
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            val = value;
            left = null;
            right = null;
        }
    }

    
    class Program
    {
       static TreeNode node;
        static void insert(TreeNode temp, int key)
        {
            if (temp == null)
            {
                node = new TreeNode(key);
                return;
            }
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(temp);

            // Do level order traversal until we find
            // an empty place.
            while (q.Count != 0)
            {
                temp = q.Peek();
                q.Dequeue();

                if (temp.left == null)
                {
                    temp.left = new TreeNode(key);
                    break;
                }
                else
                    q.Enqueue(temp.left);

                if (temp.right == null)
                {
                    temp.right = new TreeNode(key);
                    break;
                }
                else
                    q.Enqueue(temp.right);
            }
        }

        static void inorder(TreeNode temp)
        {
            if (temp == null)
                return;

            inorder(temp.left);
            Console.Write(temp.val + " ");
            inorder(temp.right);
        }

        static bool CheckTreeIsSameOrNot(TreeNode p, TreeNode q)
        {
            //traversing both tree is any one element not match return false and break the loop
            if (p == null && q == null)
                return true;
            else if ((p == null && q != null) || (p != null && q == null))
                return false;
            else
            {
                if (p.val != q.val)
                    return false;
                else
                    return CheckTreeIsSameOrNot(p.left, q.left) && CheckTreeIsSameOrNot(p.right, q.right);
            }

        }

        static bool IsMirror(TreeNode p, TreeNode q)
        {
            //traversing both tree is any one element not match return false and break the loop
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            
            return (p.val == q.val) && IsMirror(p.left, q.right) && IsMirror(p.right, q.left);
          

        }

        static void Main(string[] args)
        {
            TreeNode root = null;
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            
            Console.WriteLine("Inorder traversal before insertion:");
            inorder(root);
            Console.WriteLine("");
            //2nd Tree 
            TreeNode root2 = null;
            root2 = new TreeNode(1);
            root2.left = new TreeNode(2);
            root2.left.left = new TreeNode(3);

            Console.WriteLine("Inorder traversal before insertion 2nd Tree:");
            inorder(root2);


            Boolean check = CheckTreeIsSameOrNot(root, root2);

            Console.WriteLine("Both Tree are same or not! " + check);
            Console.ReadLine();

        }
    }
}
