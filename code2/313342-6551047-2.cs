        public static string HelloWorld()
        {
            return "Hello World!"; 
        }
        static void Main(string[] args)
        {
            var task = BeginTask(HelloWorld); // non-blocking call
            string result = task(); // block and wait
        }
