    public class MyList: IList<MyClass>
    {
        private static MyList _myList = null;
        private MyList()
        {
            
        }
        
        //This is the factory method
        public static MyList GetInstance(int args)
        {
            return _myList ?? (_myList = new MyList());
        }
        public IEnumerator<MyClass> GetEnumerator()
        {
            return _myList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(MyClass item)
        {
            _myList.Add(item);
        }
        public void Clear()
        {
            _myList.Clear();
        }
        public bool Contains(MyClass item)
        {
            return _myList.Contains(item);
        }
        public void CopyTo(MyClass[] array, int arrayIndex)
        {
            _myList.CopyTo(array, arrayIndex);
        }
        public bool Remove(MyClass item)
        {
            return _myList.Remove(item);
        }
        public int Count
        {
            get { return _myList.Count; }
        }
        public bool IsReadOnly
        {
            get { return _myList.IsReadOnly; }
        }
        public int IndexOf(MyClass item)
        {
            return _myList.IndexOf(item);
        }
        public void Insert(int index, MyClass item)
        {
            _myList.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _myList.RemoveAt(index);
        }
        public MyClass this[int index]
        {
            get { return _myList[index]; }
            set { _myList[index] = value; }
        }
    }
