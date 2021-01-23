        public static IEnumerable<int> GetRandomNumbers(int numValues, int maxVal)
        {
            var rand = new Random();
            var yieldedValues = new HashSet<int>();
            int counter = 0;
            while (counter < numValues)
            {
                var r = rand.Next(maxVal);
                if (yieldedValues.Add(r))
                {
                    counter++;
                    yield return r;
                }
            }
        }
