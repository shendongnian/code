    public static class Extensions
    {
        public static TResult FirstIfUniqueCount<TKey,TElement,TResult>(this IEnumerable<IGrouping<TKey,TElement>> items, Func<IGrouping<TKey,TElement>,TResult> selector)
        {
            if(!items.Any())
                return default(TResult);
            if(items.Count() < 2)
                return selector(items.First());
            var firstTwoItems = items.Take(2).ToArray();
            if(firstTwoItems[0].Count() == firstTwoItems[1].Count())
                return default(TResult);
            return selector(firstTwoItems[0]);
        }
    }
