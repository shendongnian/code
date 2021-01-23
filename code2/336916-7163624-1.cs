    public static class EnumerableExtensions
    {
        public static IEnumerable<string> Uniquify(this IEnumerable<string> enumerable, string suffix)
        {
            HashSet<string> prevItems = new HashSet<string>();
            foreach(var item in enumerable)
            {
                var temp = item;
                while(prevItems.Contains(temp))
                {
                    temp += suffix;
                }
                prevItems.Add(temp);
                yield return temp;
            }
        }
    }
