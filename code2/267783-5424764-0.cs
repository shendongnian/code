    class Program {
        const int TimerPeriod = 5;
        static System.Threading.Timer timer;
        static AutoResetEvent ev;
        static void Main(string[] args) {
            ThreadStart start = new ThreadStart(SomeThreadMethod);
            Thread thr = new Thread(start);
            thr.Name = "background";
            thr.IsBackground = true;
            ev = new AutoResetEvent(false);
            timer = new System.Threading.Timer(Timer_TimerCallback, ev, TimeSpan.FromSeconds(TimerPeriod), TimeSpan.Zero);
            thr.Start();
            Console.WriteLine(string.Format("Timer started at {0}", DateTime.Now));
            Console.ReadLine();
        }
        static void Timer_TimerCallback(object state) {
            AutoResetEvent ev =  state as AutoResetEvent;
            Console.WriteLine(string.Format("Timer's callback method is executed at {0}, Thread: ", new object[] { DateTime.Now, Thread.CurrentThread.Name}));
            ev.Set();
        }
        static void SomeThreadMethod() {
            WaitHandle.WaitAll(new WaitHandle[] { ev });
            Console.WriteLine(string.Format("Thread is running at {0}", DateTime.Now));
        }
    }
