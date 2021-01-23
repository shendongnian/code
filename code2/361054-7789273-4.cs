    class ItemComparer : IComparer<Item>
    {
        // allow us to look up parent Items by GUID
        IDictionary<Guid, Item> itemLookup;
        public ItemComparer(IEnumerable<Item> list)
        {
            itemLookup = list.ToDictionary(item => item.ID);
            foreach (var item in list)
                SetLevel(item);
        }
        int SetLevel(Item item)
        {
            if (item.Level == 0 && item.ParentID.HasValue)
                item.Level = 1 + itemLookup[item.ParentID.Value].Level;
            return item.Level;
        }
        public int Compare(Item x, Item y)
        {
            // see if x is a child of y
            while (x.Level > y.Level)
            {
                if (x.ParentID == y.ID)
                    return 1;
                x = itemLookup[x.ParentID.Value];
            }
            // see if y is a child of x
            while (y.Level > x.Level)
            {
                if (y.ParentID == x.ID)
                    return -1;
                y = itemLookup[y.ParentID.Value];
            }
            // x and y are not parent-child, so find common ancestor
            while (x.ParentID != y.ParentID)
            {
                x = itemLookup[x.ParentID.Value];
                y = itemLookup[y.ParentID.Value];
            }
            // compare createDate of children of common ancestor
            return x.CreateDate.CompareTo(y.CreateDate);
        }
    }
