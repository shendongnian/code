    public class Bag<T> : Dictionary<T, int>
    {
        public Bag(IEnumerable<T> sequence)
        {
            foreach (var item in sequence)
            {
                if (!ContainsKey(item)) this[item] = 0;
                ++this[item];
            }
        }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> BagDifference<T>(this IEnumerable<T> sequence1, IEnumerable<T> sequence2)
        {
            var bag1 = new Bag<T>(sequence1);
            var bag2 = new Bag<T>(sequence2);
            foreach (var item in bag1.Keys)
            {
                var count1 = bag1[item];
                var count2 = bag2.ContainsKey(item) ? bag2[item] : 0;
                var difference = Math.Max(0, count1 - count2);
                for (int i = 0; i < difference; i++)
                    yield return item;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = new List<string>() { "A", "B", "A", "C", "D" };
            var except = new List<string>() { "A", "B", "C", "C" };
            var difference = sequence.BagDifference(except).ToList();
        }
    }
