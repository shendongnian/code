    public class SerializeMe
    {
        private string _someString;
        public string SomeString
        {
            get
            {
                _someString = TransformToSomething();
                return _someString;
            }
        }
        public void SetString(string val) { _someString = val; }
    }
