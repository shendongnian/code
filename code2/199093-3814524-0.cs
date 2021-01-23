        public static int PerformSlowly(int id)
        {
            // Addition isn't so hard, but let's pretend.
            Thread.Sleep(10000);
            return 42 + id;
        }
        public static Task<int> PerformTask(int id)
        {
            // Here's the straightforward approach.
            return Task.Factory.StartNew(() => PerformSlowly(id));
        }
        public static Lazy<int> PerformLazily(int id)
        {
            // Start performing it now, but don't block.
            var task = PerformTask(id);
            // JIT for the value being checked, block and retrieve.
            return new Lazy<int>(() => task.Result);
        }
        static void Main(string[] args)
        {
            int i;
            // Start calculating the result, using a Lazy<int> as the future value.
            var result = PerformLazily(7);
            // Do assorted work, then get result.
            i = result.Value;
            // The alternative is to use the Task as the future value.
            var task = PerformTask(7);
            // Do assorted work, then get result.
            i = task.Result;
        }
