    class MyList<T> : IList<T> { 
        private readonly List<T> list = new List<T>();
        public T this[int index] {
            get {
                Console.WriteLine("Inside indexer!");
                return list[index];
            }
            set {
                list[index] = value;
            }
        }
     
        public void Add(T item) {
            this.list.Add(item);
        }
   
        public int Count {
            get {
                Console.WriteLine("Inside Count!");
                return this.list.Count;
            }
        }
        // all other IList<T> interface members throw NotImplementedException
    }
