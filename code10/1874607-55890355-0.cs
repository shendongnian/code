    using System;
    using System.Threading;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                //ManualCancelation();
                //ByTimerCancelation();
            }
    
            private static void ManualCancelation()
            {
                var infiniteAction = new InfiniteAction(Rogue.RogueFunction);
                Console.WriteLine("RogueFunction is executing.");
                infiniteAction.Start();
    
                Console.WriteLine("Press any key to stop it.");
                Console.ReadKey();
                Console.WriteLine();
                infiniteAction.Stop();
    
                Console.WriteLine("Make sure it has stopped and press any key to exit.");
                Console.ReadKey();
                Console.WriteLine();
            }
    
            private static void ByTimerCancelation()
            {
                var interval = 3000;
                var infiniteAction = new InfiniteAction(Rogue.RogueFunction);
                Console.WriteLine($"RogueFunction is executing and will be stopped in {interval} ms.");
                Console.WriteLine("Make sure it has stopped and press any key to exit.");
                infiniteAction.Start();
                var timer = new Timer(StopInfiniteAction, infiniteAction, interval, -1);
                Console.ReadKey();
                Console.WriteLine();
            }
    
            private static void StopInfiniteAction(object action)
            {
                var infiniteAction = action as InfiniteAction;
                if (infiniteAction != null)
                    infiniteAction.Stop();
                else
                    throw new ArgumentException($"Invalid argument {nameof(action)}");
            }
        }
    
        public class InfiniteAction
        {
            private readonly Action action;
            private CancellationTokenSource cts;
            private bool isRunning = false;
    
            public InfiniteAction(Action action)
            {
                this.action = action;
            }
    
            public void Start()
            {
                if (!isRunning)
                {
                    isRunning = true;
    
                    Thread t = new Thread(() => action());
                    t.IsBackground = true;
                    cts = new CancellationTokenSource();
                    cts.Token.Register(t.Abort);
                    t.Start();
                }
            }
    
            public void Stop()
            {
                if (isRunning)
                {
                    isRunning = false;
    
                    cts.Cancel();
                    cts.Dispose();
                }
            }
        }
    
        static class Rogue
        {
            // This is 3rd party function so I can't make it take a cancellation token.
            public static void RogueFunction()
            {
                while (true)
                {
                    Console.WriteLine("RogueFunction works");
                    Thread.Sleep(1000);
                }
            }
        }
    }
