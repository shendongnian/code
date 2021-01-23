        static string GetSomething()
        {
            return "Hello";
        }
        static void Method1()
        {
            string result = GetSomething();
        }
        static void Method2()
        {
            GetSomething();
        }
