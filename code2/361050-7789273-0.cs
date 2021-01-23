    class ItemComparer : IComparer<Item>
    {
        // allow us to look up parent Items by GUID
        IDictionary<Guid, Item> itemLookup;
        public ItemComparer(IEnumerable<Item> list)
        {
            itemLookup = list.ToDictionary(item => item.ID);
        }
        public int Compare(Item x, Item y)
        {
            while (x.Level > y.Level)
            {
                if (x.ParentID == y.ID)
                    return 1;
                x = itemLookup[x.ParentID.Value];
            }
            while (y.Level > x.Level)
            {
                if (y.ParentID == x.ID)
                    return -1;
                y = itemLookup[y.ParentID.Value];
            }
            while (x.ParentID != y.ParentID)
            {
                x = itemLookup[x.ParentID.Value];
                y = itemLookup[y.ParentID.Value];
            }
            return x.CreateDate.CompareTo(y.CreateDate);
        }
    }
