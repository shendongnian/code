    public class DelayedExecutionIEnumerable<T> : IEnumerable<T>
    {
        List<Lazy<T>> LazyItems;
        
        public DelayedExecutionIEnumerable(IEnumerable<T> items, Action<T> action)
        {
            // Wrap items into our List of Lazy items, the action predicate
            // will be executed only once on each item the first time it is iterated.
            this.LazyItems = items.Select(
                item => new Lazy<T>(
                    () => 
                        {
                            action(item);
                            return item;
                        }, 
                        true)).ToList(); // isThreadSafe = true 
        }
        #region IEnumerable<IEntity> Members
        public IEnumerator<T> GetEnumerator()
        {
            return this.LazyItems.Select(i => i.Value).GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.LazyItems.Select(i => i.Value).GetEnumerator();
        }
        #endregion
    }  
