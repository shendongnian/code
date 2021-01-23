                Func<Func<int>> counter0 = () => { var n = 0; return () => n++; };
            Console.WriteLine("Counter0:");
            var count0 = counter0();
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(count0());
            }
            var count1 = counter0();
            for (var i = 0; i < 5; i++)
            {
                
                Console.WriteLine(count1());
            }
            Console.WriteLine("Counter1:");
            Func<int> counter1 = new Func<Func<int>>(() => { var n = 0; return () => n++; })();
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(counter1());
            }
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(counter1());
            }
