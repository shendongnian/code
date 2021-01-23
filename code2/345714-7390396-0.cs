    class BoolBox
    {
        // boxing here
        private static object _true = true;
        // boxing here
        private static object _false = false;
        public static object True { get { return _true; } }
        public static object False { get { return _false; } }
    }
