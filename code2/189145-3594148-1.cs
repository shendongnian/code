    public class MyClass
    {
        private string _a = "not set";
        private string _b = "not set";
        public string A
        {
            get { return _a; }
            set { _a = value; }
        }
        public string B
        {
            get { return _b; }
            set { _b = value; }
        }
        public string C
        {
            get
            {
                if (_a != "not set" && _b != "not set")
                    return "not set";
                else
                    return "set";
            }
        }
    }
