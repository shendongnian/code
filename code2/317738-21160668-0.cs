        ThreadLocal<Random> _localRandom = new ThreadLocal<Random>(() => new Random());
        ThreadLocal<Stopwatch> _localStopwatch = new ThreadLocal<Stopwatch>(() => new Stopwatch());
        public void SomeTest()
        {
            Action someAction = () =>
                {
                    _localStopwatch.Value.Reset();
                    _localStopwatch.Value.Start();
                    Task.Delay(_localRandom.Value.Next(100, 500));
                    _localStopwatch.Value.Stop();
                    Debug.Print(_localStopwatch.Value.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
                };
            var actions = Enumerable.Range(0, 1000).Select(i => someAction).ToArray();
            Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount}, actions);
        }
