        public class SlidingStream : Stream
    {
        #region Other stream member implementations
		
		...
		
		#endregion Other stream member implementations
		
        public SlidingStream()
        {
            ReadTimeout = -1;
        }
        private readonly object _writeSyncRoot = new object();
        private readonly object _readSyncRoot = new object();
        private readonly LinkedList<ArraySegment<byte>> _pendingSegments = new LinkedList<ArraySegment<byte>>();
        private readonly ManualResetEventSlim _dataAvailableResetEvent = new ManualResetEventSlim();
        public int ReadTimeout { get; set; }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_dataAvailableResetEvent.Wait(ReadTimeout))
                throw new TimeoutException("No data available");
            lock (_readSyncRoot)
            {
                int currentCount = 0;
                int currentOffset = 0;
                while (currentCount != count)
                {
                    ArraySegment<byte> segment = _pendingSegments.First.Value;
                    _pendingSegments.RemoveFirst();
                    int index = segment.Offset;
                    for (; index < segment.Count; index++)
                    {
                        if (currentOffset < offset)
                        {
                            currentOffset++;
                        }
                        else
                        {
                            buffer[currentCount] = segment.Array[index];
                            currentCount++;
                        }
                    }
                    if (currentCount == count)
                    {
                        if (index < segment.Offset + segment.Count)
                        {
                            _pendingSegments.AddFirst(new ArraySegment<byte>(segment.Array, index, segment.Offset + segment.Count - index));
                        }
                    }
                    if (_pendingSegments.Count == 0)
                    {
                        _dataAvailableResetEvent.Reset();
                        return currentCount;
                    }
                }
                return currentCount;
            }
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            lock (_writeSyncRoot)
            {
                byte[] copy = new byte[count];
                Array.Copy(buffer, offset, copy, 0, count);
                _pendingSegments.AddLast(new ArraySegment<byte>(copy));
                _dataAvailableResetEvent.Set();
            }   
        }
    }
