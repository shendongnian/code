    public class Processor
    {
        private const int count = 3;
        private ConcurrentQueue<StreamWriter> queue = new ConcurrentQueue<StreamWriter>();
        private Semaphore semaphore = new Semaphore(count, count);
        public Processor()
        {
            // Populate the resource queue.
            for (int i = 0; i < count; i++) queue.Enqueue(new StreamWriter("sample" + i));
        }
        public void Process(int parameter)
        {
            // Wait for one of our resources to become free.
            semaphore.WaitOne();
            StreamWriter resource;
            queue.TryDequeue(out resource);
            // Dispatch the work to a task.
            Task.Factory.StartNew(() => Process(resource, parameter));
        }
        private Random random = new Random();
        private void Process(StreamWriter resource, int parameter)
        {
            // Do work in background with resource.
            Thread.Sleep(random.Next(10) * 100);
            resource.WriteLine("Parameter = {0}", parameter);
            queue.Enqueue(resource);
            semaphore.Release();
        }
    }
