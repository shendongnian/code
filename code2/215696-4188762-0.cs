    public class ProducerConsumer
    {
        private BlockingCollection<object> m_Queue = new BlockingCollection<object>();
    
        public ProducerConsumer()
        {
            new Thread(Producer).Start();
            new Thread(Consumer).Start();
        }
    
        private void Consumer()
        {
            while (true)
            {
                object item = m_Queue.Take(); // blocks when the queue is empty
                Console.WriteLine("Consumer");
            }
        }
    
        private void Producer()
        {
            while (true)
            {
                m_Queue.Add(new object());
                Thread.Sleep(1000);
            }
        }
    }
