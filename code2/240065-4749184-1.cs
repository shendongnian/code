    public class MyClass
        {
            private List<string> _myList;
            public ReadOnlyCollection<string> PublicReadOnlyList { get { return _myList.AsReadOnly(); } }
    
            public MyClass()
            {
                _myList = new List<string>();
                _myList.Add("tesT");
                _myList.Add("tesT1");
                _myList.Add("tesT2");
    
                //(_myList.AsReadOnly() as List<string>).Add("test 5");
            }
    
        }
