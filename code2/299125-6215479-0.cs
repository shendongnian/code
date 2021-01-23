    public class Runner
    {
        private BlockingCollection<int> queue = new BlockingCollection<int>();
        private Random random = new Random();
        public Runner()
        {
            for (int i = 0; i < 2; i++)
            {
                var thread = new Thread(Produce);
                thread.Start();
            }
            for (int i = 0; i < 2; i++)
            {
                var thread = new Thread(Consume);
                thread.Start();
            }
        }
        protected void Produce()
        {
            while (true)
            {
                int number = random.Next(0, 99);
                queue.Add(number);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Produce: " + number);
            }
        }
        protected void Consume()
        {
            while (true)
            {
                int number = queue.Take();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Consume: " + number);
            }
        }
    }
