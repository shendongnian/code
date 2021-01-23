    public static class Program
    {
        public static IEnumerable<Point> ToPoints(this IEnumerable<int> flat)
        {
            int idx = 0;
            while(true)
            {
                int[] parts = flat.Skip(idx).Take(2).ToArray();
                if (parts.Length != 2)
                    yield break;
                idx += 2;
                yield return new Point(parts[0], parts[1]);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
            var x = arr.ToPoints().ToArray();
            return;
        }
   }
