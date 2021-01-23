    internal class GetTickCount64TimeProvider : ITimeProvider
    {
        private readonly INativeMethods _nativeMethods;
        public GetTickCount64TimeProvider(INativeMethods nativeMethods)
        {
            _nativeMethods = nativeMethods;
        }
        public Timestamp Now()
        {
            var gtc = _nativeMethods.GetTickCount64();
            var getTickCountStamp = Timestamp.FromMilliseconds(gtc);
            return getTickCountStamp;
        }
    }
