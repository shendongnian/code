    public static TimeSpan Measure(Action method)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            method.Invoke();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
        public static TimeSpan ExecTime(Action method)
        {
            var ExecutionTime = Measure(() => method.Invoke());
            return ExecutionTime;
        }
        private static void Main(string[] args)
        {
            var spentTime = ExecTime(() => Sum(1,2));
        }
        public static int Sum(int t1, int t2)
        {
            return t1 + t2;
        }
