       static void Main(string[] args)
        {
            List<string> p = new List<string>() { "Test", "Test2", "Test3"};
            Parallel.ForEach(p, Test);
        }
        public static void Test(string test)
        {
            Debug.WriteLine(test);
        }
