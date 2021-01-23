    public static class TimerCalls
    {
        private static Dictionary _Stopwatches = new Dictionary();
     
        [ConditionalAttribute("TIMERS")]
        public static void StartStopwatch(string key)
        {
            if (_Stopwatches.ContainsKey(key)) //Stopwatch already running
                return;
     
            _Stopwatches.Add(key, Stopwatch.StartNew());
        }
     
        [ConditionalAttribute("TIMERS")]
        public static void StopStopwatch(string key)
        {
            if (!_Stopwatches.ContainsKey(key))//No such stopwatch currently
                return;
     
            var watch = _Stopwatches[key];
            watch.Stop();
            _Stopwatches.Remove(key);
            Debug.WriteLine(String.Format("Timer: {0}, {1}ms ---- {2}", key,
                watch.Elapsed.TotalMilliseconds, DateTime.Now));
        }
    }
