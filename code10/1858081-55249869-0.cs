    public static class RangeExtensions
    {
        public static int Normalize(this Index index, int length) => 
               index.FromEnd ? length - index.Value : index.Value;
    
        public static (int start, int end) Normalize(this Range range, int length) => 
               (range.Start.Normalize(length), range.End.Normalize(length));
    
        public static IEnumerable<T> Enumerate<T>(this T[] items, Range range)
        {
            var (start, end) = range.Normalize(items.Length);
    
            return start <= end ? items[range] : GetRangeReverse();
            IEnumerable<T> GetRangeReverse()
            {
                for (int i = start; i >= end; i--)
                    yield return items[i];
            }
        }
    }
    ...
    var numbers = Enumerable.Range(0, 10).ToArray();
    foreach (var num in numbers.Enumerate(^3..1))
        Console.WriteLine(num);
