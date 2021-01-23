        public static class TreeHelpers
        {
            public static IEnumerable<TItem> GetAncestors<TItem>(TItem item, Func<TItem, TItem> getParentFunc)
            {
                if (getParentFunc == null)
                {
                    throw new ArgumentNullException("getParentFunc");
                }
                if (ReferenceEquals(item, null)) yield break;
                for (TItem curItem = getParentFunc(item); !ReferenceEquals(curItem, null); curItem = getParentFunc(curItem))
                {
                    yield return curItem;
                }
            }
            //TODO: Add other methods, for example for 'prefix' children recurence enumeration
        }
