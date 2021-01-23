        private class test
        {
            ~test()
            {
            }
        }
        static void Main()
        {
            while (true)
            {
                GC.Collect();
                test t = new test();
            }
        }
