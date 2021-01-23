    class Table<TKey, TValues>
    {
        Dictionary<TKey, int> lookup;
        List<TValues[]> array;
        public Table()
        {
            this.lookup = new Dictionary<TKey, int>();
            this.array = new List<TValues[]>();
        }
        public void Add(TKey key, params TValues[] values)
        {
            array.Add(values);
            lookup.Add(key, array.Count - 1);
        }
        public TValues[] this[TKey key]
        {
            get { return array[lookup[key]]; }
            set { array[lookup[key]] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Table<int, string> table = new Table<int, string>();
            table.Add(10001, "Joe", "Curly", "Mo");
            table.Add(10002, "Alpha", "Beta");
            table.Add(10101, "UX-300", "UX-201", "HX-100b", "UT-910");
            string[] parts = table[10101];
            // returns "UX-300", "UX-201", "HX-100b" and "UT-910".
        }
    }
