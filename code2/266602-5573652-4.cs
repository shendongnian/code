    internal class Test:CcrServiceBase
    {
        private readonly Port<int> intPort = new Port<int>();
        private Timer timer;
        public Test() : base(new DispatcherQueue("DefaultDispatcherQueue",
                                                 new Dispatcher(0,
                                                                "dispatcher")))
        {
            
        }
        public void StartTest() {
            SpawnIterator(ProcessInts);
            var counter = 0;
            timer = new Timer(x =>
                              {
                                  for (var i = 0; i < 1500; ++i)
                                      intPort.Post(counter++);
                              }
                              ,
                              null,
                              0,
                              1000);
        }
        public IEnumerator<ITask> ProcessInts()
        {
            while (true)
            {
                yield return intPort.Receive();
                int currentValue = intPort;
                ReportCurrent(currentValue);
                while(intPort.Test(out currentValue))
                {
                    ReportCurrent(currentValue);
                }
            }
        }
        private void ReportCurrent(int currentValue)
        {
            if (currentValue % 1000 == 0)
            {
                Console.WriteLine("{0}, Current Items In Queue:{1}",
                                  currentValue,
                                  intPort.ItemCount);
            }
        }
    }
