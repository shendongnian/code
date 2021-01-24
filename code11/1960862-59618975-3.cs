    class ItemEqualityComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.Id == y.Id && x.Name == y.Name &&
                Enumerable.SequenceEqual(x.Children, y.Children,
                    ChildItemEqualityComparer.Instance);
        }
        public int GetHashCode(Item item)
        {
            int hash = 43;
            unchecked {
                hash = 17 * hash + (item.Id?.GetHashCode() ?? 0);
                hash = 17 * hash + (item.Name?.GetHashCode() ?? 0);
                foreach (ChildItem childItem in item.Children) {
                    hash = 17 * hash + (childItem.ChildItemName?.GetHashCode() ?? 0);
                }
            }
            return hash;
        }
    }
