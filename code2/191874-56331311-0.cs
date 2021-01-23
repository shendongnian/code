        public T RandomChoice<T>(IEnumerable<T> a, IEnumerable<double> p)
        {
            IEnumerator<T> ae = a.GetEnumerator();
            Random random = new Random();
            double target = random.NextDouble();
            double accumulator = 0;
            foreach (var prob in p)
            {
                ae.MoveNext();
                accumulator += prob;
                if (accumulator > target)
                {
                    break;
                }
            }
            return ae.Current;
        }
