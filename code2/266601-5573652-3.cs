    internal class Test : CcrServiceBase
    {
        private readonly Port<int> intPort = new Port<int>();
        private Timer timer;
        public Test() : base(new DispatcherQueue("DefaultDispatcherQueue",
                                                 new Dispatcher(0,
                                                                "dispatcher")))
        {
            
        }
        public void StartTest()
        {
            Activate(
                Arbiter.Receive(true,
                                intPort,
                                i =>
                                {
                                    ReportCurrent(i);
                                    int currentValue;
                                    while (intPort.Test(out currentValue))
                                    {
                                        ReportCurrent(currentValue);
                                    }
                                }));
            var counter = 0;
            timer = new Timer(x =>
                              {
                                  for (var i = 0; i < 500000; ++i)
                                  {
                                      intPort.Post(counter++);
                                  }
                              }
                              ,
                              null,
                              0,
                              1000);
        }
        private void ReportCurrent(int currentValue)
        {
            if (currentValue % 1000000 == 0)
            {
                Console.WriteLine("{0}, Current Items In Queue:{1}",
                                  currentValue,
                                  intPort.ItemCount);
            }
        }
    }
