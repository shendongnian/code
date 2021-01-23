    namespace ConsoleApplication1
    {
        public class binarytreeNode
        {
            public binarytreeNode Left;
            public binarytreeNode Right;
            public int data;
            
        }
        public class binarytree
        {
            public binarytreeNode AddNode(int value)
                {
                    binarytreeNode newnode = new binarytreeNode();
                    newnode.Left = null;
                    newnode.Right = null;
                    newnode.data = value;
                    return newnode;
                }
        }
        class Program
        {       
         
             static void Main(string[] args)
            {
                binarytree mybtree = new binarytree();
    
                binarytreeNode head = mybtree.AddNode(4);
    
            }
        }
    }
