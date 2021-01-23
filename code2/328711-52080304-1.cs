    [Serializable]
    public class MyClass
    {
        int _myValue;
        public int MyValue
        {
            get { return _myValue; }
            private set { _myValue = value; }
        }
        ...
    }
