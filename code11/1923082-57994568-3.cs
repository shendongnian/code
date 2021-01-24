    class MyObjectNameComparer : IComparer<MyObject>
    {
        public int Compare(MyObject x, MyObject y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
    myList.Sort(new MyObjectNameComparer());
