    public abstract class BufferedRecordWriter<T> : IRecordWriter<T>
    {
        private readonly ConcurrentQueue<T> _buffer = new ConcurrentQueue<T>();
        private readonly int _maxCapacity;
        private bool _flushing;
        public ConcurrentQueueRecordOutput(int maxCapacity = 100)
        {
            _maxCapacity = maxCapacity;
        }
        public void WriteRecord(T record)
        {
            _buffer.Enqueue(record);
            if (_buffer.Count >= _maxCapacity && !_flushing)
                Flush();
        }
        public void Flush()
        {
            _flushing = true;
            try
            {
                var recordsToWrite = new List<T>();
                while (_buffer.TryDequeue(out T dequeued))
                {
                    recordsToWrite.Add(dequeued);
                }
                if(recordsToWrite.Any())
                    WriteRecords(recordsToWrite);
            }
            finally
            {
                _flushing = false;
            }
        }
        protected abstract void WriteRecords(IEnumerable<T> records);
    }
