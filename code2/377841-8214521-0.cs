    public class LinqLookup<TItem>
    {
        private IList<Item> items = null;
        Func<Item, bool> predicate = i => i.IsWithinRange(day);
    
        public IterationLookup(IEnumerable<TItem> items, Func<TItem, TKey> keySelector)
        {
            this.items = items.OrderByDescending(keySelector).ToList();
        }
    
        public TItem GetItem(DateTime day)
        {
            return this.items.FirstOrDefault(predicate);
        }
    }
