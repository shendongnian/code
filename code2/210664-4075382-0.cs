     public static class EnumerableExtension
        {
    
            public static int FirstIndexMatch<TItem>(this IEnumerable<TItem> items, Func<TItem,bool> matchCondition)
            {
                var index = 0;
                foreach (var item in items)
                {
                    if(matchCondition.Invoke(item))
                    {
                        return index;
                    }
                    index++;
                }
                return -1;
            }
        }
