        private static long MeasureDuration(Action algorithm)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            algorithm.Invoke();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
