    using System;
    using System.Windows.Threading;
    using System.Threading;
    namespace dispatchertest
    {
        public class Dispatched : DispatcherObject
        {
            readonly object Lock = new object();
            readonly string _name;
            public string Name { get { return _name; } }
            public Dispatched(string name) {
                this._name = name;
            }
            public void tick(object sender, EventArgs e) {
                lock ( Lock ) {
                    Console.WriteLine("{0} in thread {1}", Name, Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
        class Program
        {
            static void Main(string[] args) {
                var timer = new DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
                Thread thread1 = new Thread(() => {
                    var d2 = Dispatcher.CurrentDispatcher;
                    var foo = new Dispatched("Foo");
                    var timer1 = new DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
                    timer1.Interval = new TimeSpan(0,0,0,0, milliseconds: 809);
                    timer1.Tick += foo.tick;
                    timer1.Start();
                    Dispatcher.Run();
                });
                var bar = new Dispatched("Bar");
                timer.Tick += bar.tick;
                thread1.Start();
                timer.Interval = new TimeSpan(0,0,0,0, milliseconds: 1234);
                timer.Start();
                Dispatcher.Run();
            }
        }
    }
