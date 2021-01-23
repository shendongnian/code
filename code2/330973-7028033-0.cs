    [Serializable()]
    public class Foo
    {
        private List<string> _myList = new List<string>(new string[] { "Some", "Data" });
    
        public List<string> MyList
        {
            get { _myList = value;}
            set { return _myList; }
        }
       
        public Foo() {}
    }
