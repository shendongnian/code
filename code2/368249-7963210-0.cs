    public static int DistinctCount(this IEnumerable<int> values)
            {
            int max = values.Max();
            int last = int.MinValue;
            int result = 0;
            do
            {
                int current = int.MaxValue;
                foreach (int value in values)
                {
                    if (value < current && value > last)
                    {
                        current = value;
                    }
                }
                result++;
                last = current;
            } while (last != max);
            return result;
        }
