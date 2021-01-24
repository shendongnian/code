    namespace MyApp.Utilities
    {
        private static string _myAwesomeString;
        public static string MyAwesomeString
        {
            get
            {
                if (string.IsNullOrEmpty(_myAwesomeString))
                {
                    MyAwesomeString= GetTranslation("MyAwesomeResource");
                }
                return _myAwesomeString;
            }
            private set => _myAwesomeString = value;
        }
    }
