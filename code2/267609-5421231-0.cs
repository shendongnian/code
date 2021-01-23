    var actions = new List<Func<int>>();
            IEnumerable<int> values = new List<int> { 1, 2, 3 };
            foreach (int value in values)
            {
                var v = value;
                actions.Add(() => v * v);
            }
            foreach (var action in actions)
            {
                Console.WriteLine(action()); ;
            }
            Console.ReadLine();
