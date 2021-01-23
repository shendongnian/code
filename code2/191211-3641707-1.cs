    public class Program
    {
        static void Main(string[] args)
        {
            // Create a Name instance by calling it's constructor
            // capable of storing 1 string
            Name n = new Name(1);
            // Store a string in the name
            n[0] = "hgfhf";
            // Retrieve the stored string
            string nam = n[0];
        }
    }
    
    public class Name
    {
        private string[] names;
        private int size;
    
        public Name(int size)
        {
            // initialize the names array for the given size
            this.names = new string[size];
            // store the size in a private field
            this.size = size;
        }
   
        /// <summary>
        /// Indexer property allowing to access the private names array
        /// given an index
        /// </summary>
        /// <param name="pos">The index to access the array</param>
        /// <returns>The value stored at the given position</returns>
        public string this[int pos]
        {
            get
            {
                return names[pos];
            }
            set
            {
                names[pos] = value;
            }
        }
    }
