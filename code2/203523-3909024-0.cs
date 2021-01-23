    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace MynahBirds
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Minah> minahs = new List<Minah>();
                for (int i = 0; i < 10; i++)
                {
                    minahs.Add(new Minah());
                }
                foreach (var item in minahs)
                {
                    item.peers = minahs;
                }
                minahs.ForEach(m => m.s.OnNext("Mine"));
                minahs.ForEach(m => m.s.OnNext("Whee"));
                minahs.ForEach(m => m.s.OnNext("Argh"));
                Console.ReadLine();
            }
        }
        class Minah
        {
            Guid Id;
            public List<Minah> peers;
            IDisposable subscription;
            public ISubject<string> s = new Subject<string>();
            public Minah()
            {
                try
                {
                    this.Id = Guid.NewGuid();
                    subscription = s.Subscribe((string a) =>
                    {
                        Console.WriteLine("{0} : {1}", this.Id, a);
                    },
                    (Exception ex) =>
                    {
                        Console.WriteLine("Error {0} hit", ex.ToString());
                    },
                    () => { });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                    throw;
                }
            }
        }
    }
