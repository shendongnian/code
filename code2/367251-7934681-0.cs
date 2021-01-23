    using System;
    using System.Threading;
    
    class Program {
        static void Main(string[] args) {
            EventHandler handler = null;
            var t1 = ThreadPool.QueueUserWorkItem((w) => {
                for (; ; ) {
                    handler += Test;
                    handler -= Test;
                }
            });
            var t2 = ThreadPool.QueueUserWorkItem((w) => {
                for (; ; ) {
                    if (handler != null) handler(null, null);
                }
            });
            Console.ReadLine();
        }
    
        static void Test(object sender, EventArgs e) { }
    }
