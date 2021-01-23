    public class MyClass
    {
        public IList<byte> MyList
        {
            get { return _myList; }
        }
        private IList<byte> _myList = new ObservableCollection<byte>();
        ...
    }
