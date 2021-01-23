        static void Main(string[] args)
        {
            int numberOfNodes = 10;
            
            Random rand = new Random();
            int[] randomValues = Enumerable.Repeat(0, numberOfNodes).Select(i => rand.Next(0, 100)).ToArray();
            
            //sort the array
            int[] binaryTreeValues = (from x in randomValues orderby x select x).ToArray();
            BNode root = null;
            Construct(ref root, ref binaryTreeValues, 0, binaryTreeValues.Length - 1);
             
        }
        public static void Construct(ref BNode root, ref int[] array, int start, int end)
        {
            if (start > end)
            {
                root = null;
            }
            else if (start == end)
            {
                root = new BNode(array[start]);
            }
            else
            {
                int split = (start + end) / 2;
                root = new BNode(array[split]);
                Construct(ref root.Left, ref array, start, split - 1);
                Construct(ref root.Right, ref array, split + 1, end);
            }
        }
    public class BNode
    {
        public int ID;
        public int Level;
        public BNode Left;
        public BNode Right;
        public BNode(int ID)
        {
            this.ID = ID;
        }
        public override string ToString()
        {
            return this.ID.ToString();
        }
    }
