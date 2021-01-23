        public class myClass
        {
            private string _myString;
            public string myString
            {
                get { return _myString; }
            }
        }
        public partial class myClass
        {
            public void doSomething()
            {
                _myString = "newString";
            }
        }
