    public class ClassUsingHashSet
    {
        private static readonly List<int> PreallocationList
            = Enumerable.Range(0, 10000).ToList();
        public ClassUsingHashSet()
        {
            this.hashSet = new HashSet<int>(PreallocationList);
            this.hashSet.Clear();
        }
   
        public void Add(int item)
        {
            this.hashSet.Add(item);
        }
        private HashSet<int> hashSet;
    }
