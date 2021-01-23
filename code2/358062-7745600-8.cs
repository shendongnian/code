    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Diagnostics;
    using System.Threading;
    using System.Runtime.Serialization;
    
    namespace StockApp
    {
        [DataContract]
        public class Stock
        {
            [DataMember]
            public DateTime FirstDealDate { get; set; }
            [DataMember]
            public DateTime LastDealDate { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndDate { get; set; }
            [DataMember]
            public decimal Open { get; set; }
            [DataMember]
            public decimal High { get; set; }
            [DataMember]
            public decimal Low { get; set; }
            [DataMember]
            public decimal Close { get; set; }
            [DataMember]
            public decimal VolumeWeightedPrice { get; set; }
            [DataMember]
            public decimal TotalQuantity { get; set; }
        }
    
        [ServiceContract]
        public interface IStock
        {
            [OperationContract(IsOneWay = true)]
            void GetStocks(string address);
        }
    
        [ServiceContract]
        public interface IPutStock
        {
            [OperationContract(IsOneWay = true)]
            void PutStock(Stock stock);
        } 
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class StocksService : IStock
        {
            public void SendStocks(object obj)
            {
                string address = (string)obj;
                ChannelFactory<IPutStock> factory = new ChannelFactory<IPutStock>("CallbackClientEndpoint");
                IPutStock callback = factory.CreateChannel(new EndpointAddress(address));
    
                Stock st = null; st = new Stock
                {
                    FirstDealDate = System.DateTime.Now,
                    LastDealDate = System.DateTime.Now,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now,
                    Open = 495,
                    High = 495,
                    Low = 495,
                    Close = 495,
                    VolumeWeightedPrice = 495,
                    TotalQuantity = 495
                };
    
                for (int i = 0; i < 1000; ++i)
                    callback.PutStock(st);
    
                //Console.WriteLine("Done calling {0}", address);
    
                ((ICommunicationObject)callback).Shutdown();
                factory.Shutdown();
            }
    
            public void GetStocks(string address)
            {
                /// WCF service methods execute on IO threads. 
                /// Passing work off to worker thread improves service responsiveness... with a measurable cost in total runtime.
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(SendStocks), address);
    
                // SendStocks(address);
            }
        } 
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
        public class Callback : IPutStock
        {
            public static int CallbacksCompleted = 0;
            System.Diagnostics.Stopwatch timer = Stopwatch.StartNew();
            int n = 0;
    
            public void PutStock(Stock st)
            {
                ++n;
                if (n == 1000)
                {
                    //Console.WriteLine("1,000 results in " + this.timer.Elapsed.TotalSeconds + "s");
                    
                    int compelted = Interlocked.Increment(ref CallbacksCompleted);
                    if (compelted % 100 == 0)
                    {
                        Console.WriteLine("Client #{0} completed 1,000 results in {1} s", compelted, this.timer.Elapsed.TotalSeconds);
    
                        if (compelted == Program.CLIENT_COUNT)
                        {
                            Console.WriteLine("ALL DONE. Total number of clients: {0} Total runtime: {1} msec", Program.CLIENT_COUNT, Program.ProgramTimer.ElapsedMilliseconds);
                        }
                    }
                }
            }
        }
    
        class Program
        {
            public const int CLIENT_COUNT = 1000;           // TEST WITH DIFFERENT VALUES
    
            public static System.Diagnostics.Stopwatch ProgramTimer;
    
            static void StartCallPool(object uriObj)
            {
                string callbackUri = (string)uriObj;
                ChannelFactory<IStock> factory = new ChannelFactory<IStock>("StockClientEndpoint");
                IStock proxy = factory.CreateChannel();
    
                proxy.GetStocks(callbackUri);
    
                ((ICommunicationObject)proxy).Shutdown();
                factory.Shutdown();
            }
    
            static void Test()
            {
                ThreadPool.SetMinThreads(CLIENT_COUNT, CLIENT_COUNT * 2);
    
                // Create all the hosts that will recieve call backs.
                List<ServiceHost> callBackHosts = new List<ServiceHost>();
                for (int i = 0; i < CLIENT_COUNT; ++i)
                {
                    string port = string.Format("{0}", i).PadLeft(3, '0');
                    string baseAddress = "net.tcp://localhost:7" + port + "/";
                    ServiceHost callbackHost = new ServiceHost(typeof(Callback), new Uri[] { new Uri( baseAddress)});
                    callbackHost.Open();
                    callBackHosts.Add(callbackHost);            
                }
                Console.WriteLine("All client hosts open.");
    
                ServiceHost stockHost = new ServiceHost(typeof(StocksService));
                stockHost.Open();
    
                Console.WriteLine("Service Host opened. Starting timer...");
                ProgramTimer = Stopwatch.StartNew();
    
                foreach (var callbackHost in callBackHosts)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(StartCallPool), callbackHost.BaseAddresses[0].AbsoluteUri);
                }
    
                Console.WriteLine("Press ENTER to close the host once you see 'ALL DONE'.");
                Console.ReadLine();
    
                foreach (var h in callBackHosts)
                    h.Shutdown();
                stockHost.Shutdown(); 
            }
    
            static void Main(string[] args)
            {
                Test();
            }
        }
    
        public static class Extensions
        {
            static public void Shutdown(this ICommunicationObject obj)
            {
                try
                {
                    obj.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Shutdown exception: {0}", ex.Message);
                    obj.Abort();
                }
            }
        }
    }
