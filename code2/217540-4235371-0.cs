    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace testo
    {
        public class MyEventThing : IDisposable
        {
            public event EventHandler Tick;
            private Timer t;
    
            public MyEventThing()
            {
                t = new Timer((s) => { OnTick(new EventArgs()); }, null, 1000, 1000);
            }
    
            protected void OnTick(EventArgs e)
            {
                if (Tick != null)
                {
                    Tick(this, e);
                }
            }
    
            ~MyEventThing()
            {
                Dispose(false);
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            private bool disposed = false;
            private void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        t.Dispose();
                        // Check to see if there are any outstanding event handlers
                        CheckHandlers();
                    }
    
                    disposed = true;
                }
            }
    
            private void CheckHandlers()
            {
                if (Tick != null)
                {
                    Console.WriteLine("Handlers still subscribed:");
                    foreach (var handler in Tick.GetInvocationList())
                    {
                        Console.WriteLine("{0}.{1}", handler.Method.DeclaringType, handler.Method.Name);
                    }
                }
            }
    
        }
    
        class Program
        {
            static public long Time(Action proc)
            {
                Stopwatch sw = Stopwatch.StartNew();
                proc();
                return sw.ElapsedMilliseconds;
            }
    
            static int Main(string [] args)
            {
                DoIt();
                Console.WriteLine();
                Console.Write("Press Enter:");
                Console.ReadLine();
                return 0;
            }
    
            static void DoIt()
            {
                MyEventThing thing = new MyEventThing();
                thing.Tick += new EventHandler(thing_Tick);
                Thread.Sleep(5000);
                thing.Dispose();
            }
    
            static void thing_Tick(object sender, EventArgs e)
            {
                Console.WriteLine("tick");
            }
        }
    }
