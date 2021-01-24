    public static class EnumerableExtensions
    {
        public static IEnumerable<T> PickAlternate<T>(this IEnumerable<T> source, int skip)
        {
            int? currentlySkipped = null;
    
            foreach (var item in source)
            {
    			if (!currentlySkipped.HasValue || currentlySkipped == skip)
    			{
    				currentlySkipped = 0;
    				yield return item;
    			}
                else
                {
                    currentlySkipped++;
                }
    
                     
             }
        }
    }
