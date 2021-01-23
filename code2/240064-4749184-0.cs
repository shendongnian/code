    public class MyClass
    {
        private List<string> _myList;
        private List<string> myList 
        { 
            get {return _myList;}
            set { _myList = value; PublicReadOnlyList = new ReadOnlyCollection<string>(_myList); }
        }
        public ReadOnlyCollection<string> PublicReadOnlyList { get; private set; }
        public MyClass()
        {
            myList = new List<string>();
            myList.Add("tesT");
            myList.Add("tesT1");
            myList.Add("tesT2");
        }
    }
