    public static class ItemCollectionExtensions
    {
        public static IEnumerable<int> GetItemIds(this List<Item> list)
        {
            return list.Select(i => i.ID);
        }
    }
