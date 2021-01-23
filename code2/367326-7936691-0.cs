    class Producer
    {
        private readonly BlockingQueue<Task> _queue;
        
        public Producer(BlockingQueue<task> queue)
        {
            _queue = queue;
        }
        
        public LoadImages(List<Task> imageLoadTasks)
        {
            foreach(Task t in imageLoadTasks)
            {
                _queue.Enqueue(task);
            }
        }
    }
    
    class Consumer
    {
        private volatile bool _running;
        private readonly BlockingQueue<Task> _queue;
        
        public Consumer(BlockingQueue<task> queue)
        {
            _queue = queue;
            _running = false;
        }
        
        public Consume()
        {
            _running = true;
            
            while(_running)
            {
                try
                {
                    // Blocks on dequeue until there is a task in queue
                    Task t = _queue.Dequeue();
                    
                    // Execute the task after it has been dequeued
                    t.Execute();
                }
                catch(ThreadInterruptedException)
                {
                    // The exception will take you out of a blocking
                    // state so you can check the running flag and decide
                    // if you need to exit the loop or if you shouldn't.
                }
            }
        }
    }
