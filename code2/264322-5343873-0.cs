    [Serializable]
    public class StopwatchAttribute : OnMethodBoundaryAspect
    {
        [ThreadStatic]
        private static Stopwatch stopwatch = null;
        public override void OnEntry(MethodExecutionArgs args)
        {
            var sw = stopwatch ?? new Stopwatch();
            args.MethodExecutionTag = sw; // Better to move this line before .Start
            sw.Start();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            var sw = (Stopwatch) args.MethodExecutionTag;
            sw.Stop();
            Debug.WriteLine("Time elapsed: {0} ms", sw.Elapsed);
        }
        public static Stopwatch Measure(Action action)
        {
            var oldStopwatch = stopwatch;
            stopwatch = new Stopwatch();
            try {
                // !!! Btw, you can measure everything right here.
                action.Invoke();
                return stopwatch;
            }
            finally {
                stopwatch = oldStopwatch;
            }
        }
    }
