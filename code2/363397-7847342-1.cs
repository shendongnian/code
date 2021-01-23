    using System;
    using System.ComponentModel;
    using System.Threading;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                BWorkerSyncExample sample = new BWorkerSyncExample();
                sample.M();
            }
        }
        class BWorkerSyncExample
        {
            BackgroundWorker worker1, worker2, worker3;
            EventWaitHandle[] waithandles;
    
            public void M()
            {
                Console.WriteLine("Starting background worker threads");
                waithandles = new EventWaitHandle[3];
    
                waithandles[0] = new EventWaitHandle(false, EventResetMode.ManualReset);
                waithandles[1] = new EventWaitHandle(false, EventResetMode.ManualReset);
                waithandles[2] = new EventWaitHandle(false, EventResetMode.ManualReset);
    
                StartBWorkerOne();
                StartBWorkerTwo();
                StartBWorkerThree();
    
                //Wait until all background worker complete or timeout elapse
                Console.WriteLine("Waiting for workers to complete...");
                WaitHandle.WaitAll(waithandles, 10000);
                Console.WriteLine("All workers finished their activities");
                Console.ReadLine();
            }
    
            void StartBWorkerThree()
            {
                if (worker3 == null)
                {
                    worker3 = new BackgroundWorker();
                    worker3.DoWork += (sender, args) =>
                                        {
                                            
                                            M3();
                                            Console.WriteLine("I am done- Worker Three");
                                        };
                    worker3.RunWorkerCompleted += (sender, args) =>
                                        {
                                            waithandles[2].Set();
                                        };
    
                }
                if (!worker3.IsBusy)
                    worker3.RunWorkerAsync();
            }
    
            void StartBWorkerTwo()
            {
                if (worker2 == null)
                {
                    worker2 = new BackgroundWorker();
                    worker2.DoWork += (sender, args) =>
                                           {
                                               
                                               M2();
                                               Console.WriteLine("I am done- Worker Two");
                                           };
                    worker2.RunWorkerCompleted += (sender, args) =>
                                           {
                                               waithandles[1].Set();
                                           };
    
                }
                if (!worker2.IsBusy)
                    worker2.RunWorkerAsync();
            }
    
            void StartBWorkerOne()
            {
                if (worker1 == null)
                {
                    worker1 = new BackgroundWorker();
                    worker1.DoWork += (sender, args) =>
                                           {
                                               
                                               M1();
                                               Console.WriteLine("I am done- Worker One");
                                           };
                    worker1.RunWorkerCompleted += (sender, args) =>
                                           {
                                               waithandles[0].Set();
                                           };
    
                }
                if (!worker1.IsBusy)
                    worker1.RunWorkerAsync();
            }
            void M1()
            {
               //do all your image processing here.
            //simulate some intensive activity.
            Thread.Sleep(3000);
            }
            void M2()
            {
              //do all your image processing here.
            //simulate some intensive activity.
            Thread.Sleep(1000);
            }
            void M3()
            {
             //do all your image processing here.
            //simulate some intensive activity.
            Thread.Sleep(4000);
            }
    
        }
    }
      
