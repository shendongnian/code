    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Collections.Concurrent;
    
    namespace MynahBirds
    {
        class Program
        {
            static void Main(string[] args)
            {
                ThreadPool.SetMaxThreads(100, 100);
    
                ConcurrentBag<Minah> minahs = new ConcurrentBag<Minah>();
                Stopwatch ti = new Stopwatch();
    
                ti.Start();
    
                Task.Factory.StartNew(() => {
                    for (int i = 1; i < 2501; i++) {
                        minahs.Add(new Minah(i));
                    };
                });
    
                Task.Factory.StartNew(() => {
                    for (int i = 1; i < 2501; i++) {
                        minahs.Add(new Minah(i));
                    };
                });
    
                Task.Factory.StartNew(() => {
                    for (int i = 1; i < 2501; i++) {
                        minahs.Add(new Minah(i));
                    };
                });
    
                Task.Factory.StartNew(() => {
                    for (int i = 1; i < 2501; i++) {
                        minahs.Add(new Minah(i));
                    };
                });
    
                Task.WaitAll();
    
                string[] alpha = { "Alpha", "Bravo", "Charlie", "Delta", "Eagle", "Foxtrot", "Gulf", "Hotel" };
    
                foreach (string s in alpha) {
                    Console.WriteLine(s);
                    Task.Factory.StartNew(() => minahs.AsParallel().ForAll(m => m.RepeatWord = s)).Wait();
                }
    
                minahs.AsParallel().ForAll(m => m.s.OnCompleted());
    
                ti.Stop();
    
                Console.WriteLine("{1} birds : {0} seconds", ti.Elapsed.TotalSeconds, minahs.Count);
                Console.ReadLine();
            }
        }
        class Minah
        {
            Guid Id;
            IDisposable subscription;
    
            public ISubject<string> s = new Subject<string>();
    
            private string _RepeatWord;
            public string RepeatWord
            {
                get
                {
                    return _RepeatWord;
                }
                set
                {
                    this.s.OnNext(value);
                    _RepeatWord = value;
                }
            }
    
            public Minah(int i)
            {
                try {
                    this.Id = Guid.NewGuid();
    
                    subscription = s.Subscribe((string a) => {
                        Console.WriteLine("{0} : {1}", i, a);
                    },
                    (Exception ex) => {
                        Console.WriteLine("Error {0} hit", ex.ToString());
                    },
                    () => { /* Console.WriteLine("{0} : Completed", this.Id); */ });
    
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                    throw;
                }
            }
        }
    }
