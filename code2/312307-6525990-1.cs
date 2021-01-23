    public class B
    {
        private string _b_string;
        private A _a = new A();
    
        public A A
        {
            get { return _a; }
            set { _a = value; }
        }
    
        public string BString
        {
            get { return _b_string;  }
            set { _b_string = value; }
        }
    }
