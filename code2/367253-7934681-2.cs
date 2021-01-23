    using System;
    using System.Threading;
    
    class Program {
        static void Main(string[] args) {
            EventHandler anEvent = null;
            var t1 = ThreadPool.QueueUserWorkItem((w) => {
                for (; ; ) {
                    anEvent += Test;
                    anEvent -= Test;
                }
            });
            var t2 = ThreadPool.QueueUserWorkItem((w) => {
                for (; ; ) {
                    if (anEvent != null) anEvent(null, null);
                }
            });
            Console.ReadLine();
        }
    
        static void Test(object sender, EventArgs e) { }
    }
