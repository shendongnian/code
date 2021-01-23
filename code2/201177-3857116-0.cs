    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            var lst = new MyList<int>();
            for (int ix = 0; ix < 10000000; ++ix) lst.Add(ix);
            for (int test = 0; test < 20; ++test) {
                var sw1 = Stopwatch.StartNew();
                foreach (var item in lst) ;
                sw1.Stop();
                var sw2 = Stopwatch.StartNew();
                foreach (var item in lst.GetItems()) ;
                sw2.Stop();
                Console.WriteLine("{0} {1}", sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
            }
            Console.ReadLine();
    
        }
    }
    
    class MyList<T> : IList<T> {
        private List<T> lst = new List<T>();
    
        public IEnumerable<T> GetItems() {
            foreach (T item in lst)
                yield return item;
        }
    
        public int IndexOf(T item) { return lst.IndexOf(item); }
        public void Insert(int index, T item) { lst.Insert(index, item); }
        public void RemoveAt(int index) { lst.RemoveAt(index); }
        public T this[int index] {
            get { return lst[index]; }
            set { lst[index] = value; }
        }
        public void Add(T item) { lst.Add(item); }
        public void Clear() { lst.Clear(); }
        public bool Contains(T item) { return lst.Contains(item); }
        public void CopyTo(T[] array, int arrayIndex) { lst.CopyTo(array, arrayIndex); }
        public int Count { get { return lst.Count; } }
        public bool IsReadOnly { get { return ((IList<T>)lst).IsReadOnly; } }
        public bool Remove(T item) { return lst.Remove(item); }
        public IEnumerator<T> GetEnumerator() { return lst.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
