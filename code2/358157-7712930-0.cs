    public void CallsCopyTest1()
    {
        var originalList = new List<int>();
        var newList = new List<int>(originalList);
        var copyTest = new CopyTest1(newList); //Modifies newList not originalList
    }
    class CopyTest1
    {
        List<int> _myList = new List<int>();
        public CopyTest1(List<int> l)
        {
            foreach (int num in l)
            {
                _myList.Add(num);
            }
            _myList.RemoveAt(0); // no effect on original List
        }
    }
