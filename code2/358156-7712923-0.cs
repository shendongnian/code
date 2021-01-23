    class CopyTest1
    {
        List<int> _myList = new List<int>();
        public CopyTest1(IList<int> l)
        {
            foreach (int num in l)
            {
                _myList.Add(num);
            }
            _myList.RemoveAt(0); // no effect on original List
        }
    }
