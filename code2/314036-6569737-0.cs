    public static class TimingExtensions
    {
        public static Func<R> Time<R>(this Func<R> target, Action<string> logger)
        {
            return delegate
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                s.Start();
                R value = target();
                s.Stop();
                logger("Function '" + target.Method.Name + "' elapsed ms: " + s.ElapsedMilliseconds); 
                return value;
            }; 
        }
    }
