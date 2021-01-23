    class Program
    {
        static void Main(string[] args)
        {
            foreach (var list in SlidingWindow<int>.Generate(new int[] { 1, 2, 3, 4, 5 }, 2, 5))
            {
                Console.WriteLine(string.Join(" & ", list));
            }
        }
    }
    static class SlidingWindow<T>
    {
        static public IEnumerable<IEnumerable<T>> Generate(IList<T> items, int minWindowSize, int maxWindowSize)
        {
            for (int i = minWindowSize; i < maxWindowSize; ++i)
            {
                foreach (var list in Generate(items, i))
                    yield return list;
            }
        }
        static public IEnumerable<IEnumerable<T>> Generate(IList<T> items, int windowSize)
        {
            for (int i = 0; i < (items.Count - windowSize + 1); ++i)
                yield return items.Skip(i).Take(windowSize);
        }
    }
