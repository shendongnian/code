    public static class EnumerableExtensions
    {
        public static IEnumerable<string> Uniquify(this IEnumerable<string> enumerable, string suffix)
        {
            List<string> prevItems = new List<string>();
            foreach(var item in enumerable)
            {
                if(prevItems.Contains(item))
                {
                    prevItems.Add(item + suffix);
                    yield return item + suffix;
                }
                else
                {
                    prevItems.Add(item);
                    yield return item;
                }
            }
        }
    }
