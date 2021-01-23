    public class ThreadSafeFileBuffer<T> : IDisposable
    {
        private readonly StreamWriter m_writer;
        private readonly ConcurrentQueue<T> m_buffer = new ConcurrentQueue<T>();
        private readonly Timer m_timer;
        public ThreadSafeFileBuffer(string filePath, int flushFrequencyInSeconds = 5)
        {
            m_writer = new StreamWriter(filePath);
            var flushFrequency = TimeSpan.FromSeconds(flushFrequencyInSeconds);
            m_timer = new Timer(FlushBuffer, null, flushFrequency, flushFrequency);
        }
        public void AddResult(T result)
        {
            m_buffer.Enqueue(result);
            Console.WriteLine("Buffer is up to {0} elements", m_buffer.Count);
        }
        public void Dispose()
        {
            Console.WriteLine("Turning off timer");
            m_timer.Dispose();
            Console.WriteLine("Flushing final buffer output");
            FlushBuffer(); // flush anything left over in the buffer
            Console.WriteLine("Closing file");
            m_writer.Dispose();
        }
        /// <summary>
        /// Since this is only done by one thread at a time (almost always the background flush thread, but one time via Dispose), no need to lock
        /// </summary>
        /// <param name="unused"></param>
        private void FlushBuffer(object unused = null)
        {
            T current;
            while (m_buffer.TryDequeue(out current))
            {
                Console.WriteLine("Buffer is down to {0} elements", m_buffer.Count);
                m_writer.WriteLine(current);
            }
            m_writer.Flush();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tempFile = Path.GetTempFileName();
            using (var resultsBuffer = new ThreadSafeFileBuffer<double>(tempFile))
            {
                Parallel.For(0, 100, i =>
                {
                    // simulate some 'real work' by waiting for awhile
                    var sleepTime = new Random().Next(10000);
                    Console.WriteLine("Thread {0} doing work for {1} ms", Thread.CurrentThread.ManagedThreadId, sleepTime);
                    Thread.Sleep(sleepTime);
                    resultsBuffer.AddResult(Math.PI*i);
                });
            }
            foreach (var resultLine in File.ReadAllLines(tempFile))
            {
                Console.WriteLine("Line from result: {0}", resultLine);
            }
        }
    }
