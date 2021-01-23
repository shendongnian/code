    public class LinqLookup<TItem, TKey>
    {
        private IList<Item> items = null;
    
        public IterationLookup(IEnumerable<TItem> items, Func<TItem, TKey> keySelector)
        {
            this.items = items.OrderByDescending(keySelector).ToList();
        }
    
        public TItem GetItem(Func<TItem, TKey> selector)
        {
            return this.items.FirstOrDefault(selector);
        }
    }
