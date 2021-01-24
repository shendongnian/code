    public class BlockTimer : IDisposable
    {
        private readonly Stopwatch _stopwatch;
 		private Action<long> _getMillisecondsFunc;
		
        public BlockTimer(Action<long> getMilliseconds)
        {
			_getMillisecondsFunc = getMilliseconds;
 
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }
        public void Dispose()
        {
            _stopwatch.Stop();
			_getMillisecondsFunc(_stopwatch.ElapsedMilliseconds);
        }
    }
