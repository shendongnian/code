    public static class IEnumerableExt {
        public static int CostOfMerge(this IEnumerable<int> psrc) {
            var src = psrc.ToList();
            src.Sort();
            while (src.Count > 1) {
                var sum = src[0]+src[1];
                src.RemoveRange(0, 2);
                var index = src.BinarySearch(sum);
                if (index < 0)
                    index = ~index;
                src.Insert(index, sum);
                total += sum;
            }
            return total;
        }
    }
