        static void Main()
        {
            new[] {"a", "b", "c", "d", "e", "f"}
                .ToObservable()
                .Scan(Enumerable.Empty<string>(), (x, y) => x.StartWith(y).Take(3))
                .Subscribe(x =>
                               {
                                   x.Run(Console.Write);
                                   Console.WriteLine();
                               });
            Console.ReadLine();
        }
