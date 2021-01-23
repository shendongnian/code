    public class ThreadStaticTest
    {
        // CLR ensures that each thread accessing this field
        // gets a separate instance of the *field*. This, however,
        // means that static initializers don't work. Field is
        // null at first access from an individual thread
        [ThreadStatic]
        static HashSet<string> _hashset;
        // This is why we instantiate it explicitly here:
        private HashSet<string> HashSet
        {
            get
            {
                _hashset = _hashset ?? new HashSet<string>();
                return _hashset;
            }
        }
        public void AddItem(string s)
        {
            // thread safe
            HashSet.Add(s);
        }
        public IEnumerable<string> GetItems()
        {
            // thread safe
            return HashSet;
        }
    }
