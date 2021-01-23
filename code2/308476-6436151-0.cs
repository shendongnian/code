    sealed class MyBool
    {
        private MyBool() {} // No one creates it!
        public static MyBool True = new MyBool();
        public static MyBool False = new MyBool();
        public static MyBool Unknown = new MyBool();
            
