        private static WriteToConsoleCallback callback;
        static void Main(string[] args)
        {
            InitializeLib();
            callback = new WriteToConsoleCallback(PrintSymbol);
            SetDelegate(callback);
            // etc...
        }
