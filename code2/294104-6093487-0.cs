    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                ExampleQueue eq = new ExampleQueue();
                eq.Run();
    
                // Wait...
                System.Threading.Thread.Sleep(100000);
            }
    
           
        }
    
        class ExampleQueue
        {
            private Queue<int> _myQueue = new Queue<int>();
    
            public void Run()
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(PushToQueue), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(PopFromQueue), null);
            }
    
            private void PushToQueue(object Dummy)
            {
                for (int i = 0; i <= 1000; i++)
                {
                    lock (_myQueue)
                    {
                        _myQueue.Enqueue(i);
                    }
                }
                System.Console.WriteLine("END PushToQueue");
    
            }
    
            private void PopFromQueue(object Dummy)
            {
                int dataElementFromQueue = -1;
                while (dataElementFromQueue < 1000)
                {
                    lock (_myQueue)
                    {
                        if (_myQueue.Count > 0)
                        {
                            dataElementFromQueue = _myQueue.Dequeue();
    
                            // Do something with dataElementFromQueue...
                            System.Console.WriteLine("Dequeued " + dataElementFromQueue);
                        }
                    }
                }
                System.Console.WriteLine("END PopFromQueue");
    
            }
        }
    }
