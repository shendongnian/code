        private class Test 
        {
            public int TestFunc(string str, int i) { return 0; }
            public int TestFunc(string str, long i) { return 0; }
        }
        public static void Main()
        {
            Test t = new Test();
            DoWork(t.TestFunc);
        }
        public static void DoWork<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
        }
