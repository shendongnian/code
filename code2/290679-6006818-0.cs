    class MyClass
    {
        private static readonly List<char> _myCharList = new List<char>() { 'x', 'y', 'z' };
        public static List<char> MyCharList
        {
            get { return _myCharList; }
            
        }
    }
