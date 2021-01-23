    public IEnumerable<T> GetRange<T>(IEnumerable<T> enumerable, int rangeSize, T value)
        {
            for (int i = 0; i < enumerable.Count(); ++i)
            {
                if (enumerable.ElementAt(i).Equals(value))
                {
                    for (int j = Math.Max(0, i - rangeSize); j < Math.Min(i + rangeSize + 1, enumerable.Count()); ++j)
                    {
                        yield return enumerable.ElementAt(j);
                    }
                }
            }
        }
    }
