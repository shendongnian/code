    public class LinkedList<T>
    {
       protected LinkedListNode<T> root = null;
       public LinkedList()
       {
       }
       public string ToString()
       {
           StringBuilder sb = new StringBuilder();
           var node = root;
           while (node != null)
           {
               sb.Append("{ " + node.Data.ToString() + " } ");
               node = node.Next;
           }
           return sb.ToString();
       }
       public T this[int index]
       {
            get
            {
               var node = GetAt(index);
               if(node == null)
                    throw new ArgumentOutOfRangeException();
               return node.Data;
            }
            set
            {
               var node = GetAt(index);
               if (node == null)
                    throw new ArgumentOutOfRangeException();
               node.Data = value;
            }
       }
        private LinkedListNode<T> GetAt(int index)
        {
            var current = root;
            for(int i=0;i<index;i++)
            {
                if (current == null)
                    return null;
                current = current.Next;
            }
            return current;
        }
        public void Add(T data)
        {
            if (root == null)
                root = new LinkedListNode<T>(data);
            else
            {
                LinkedListNode<T> current = root;
                while (current.Next != null)
                    current = current.Next;
                current.Next = new LinkedListNode<T>(data);
                current.Next.Previous = current;
            }
        }
    }
    public class LinkedListNode<T>
    {
        public T Data {get;set;}
        public LinkedListNode(T data)
        {
            Data = data;
        }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
    }
