            class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Adding elements to list");
                List<WorkItem> workItems = new List<WorkItem>(100);
                for (int i = 0; i < 1000; i++)
                {
                    workItems.Add(new WorkItem
                    {
                        TimeStamp = DateTime.Now.AddMilliseconds(i * 300)
                    });
                }
                var tw = new TimedWorker();
                tw.Process(workItems);
                Console.ReadLine();
            }
        }
        class TimedWorker
        {
            private Timer _timer;
            private Queue<WorkItem> _workItems;
            public void Process(List<WorkItem> workItems)
            {
                _timer = new Timer
                {
                    AutoReset = false,
                    Interval = 1
                };
                _workItems = new Queue<WorkItem>();
                _timer.Elapsed += Elapsed;
                foreach (var item in workItems)
                {
                    _workItems.Enqueue(item);
                }
                _timer.Start();
            }
            private void Elapsed(object sender, ElapsedEventArgs e)
            {
                ProcessNext();
            }
            private void ProcessNext()
            {
                var item = _workItems.Dequeue();
                var nextItem = _workItems.Peek();
                _timer.Interval = (nextItem.TimeStamp - item.TimeStamp).TotalMilliseconds;
                Console.WriteLine(item.TimeStamp.ToString("hh/mm/ss:FFFFFF"));
                _timer.Start();
            }
        }
        class WorkItem
        {
            public DateTime TimeStamp;
        }
