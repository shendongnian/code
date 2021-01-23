    class List
    {
        IList data;
        // called several times on thread A
        // property has no side-effects
        public int Count { get data.Length; }
 
        // called several times on thread B
        public void Add(object o)
        {
            data.Add(o);
        }
    }
