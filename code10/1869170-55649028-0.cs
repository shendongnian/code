        private static List<int> PrimeNumbers(int input)
        {
            var bag = new ConcurrentBag<int>();
            Parallel.ForEach(Enumerable.Range(2, input), x =>
            {
                var isPrime = true;
                Parallel.ForEach(Enumerable.Range(2, input), (y, state) =>
                {
                    if ((x != y) && (x % y) == 0)
                    {
                        isPrime = false;
                        state.Break();
                    }
                });
                if (isPrime)
                    bag.Add(x);
            });
            return bag.AsEnumerable().OrderBy(x => x).ToList();
        }
