    class FlattenTree
    {
        // map each item to its children
        ILookup<Item, Item> mapping;
        public FlattenTree(IEnumerable<Item> list)
        {
            var itemLookup = list.ToDictionary(item => item.ID);
            mapping = list.Where(i => i.ParentID.HasValue)
                          .ToLookup(i => itemLookup[i.ParentID.Value]);
        }
        IEnumerable<Item> YieldItemAndChildren(Item node)
        {
            yield return node;
            foreach (var child in mapping[node].OrderBy(i => i.CreateDate))
                foreach (var grandchild in YieldItemAndChildren(child))
                    yield return grandchild;
        }
        public IEnumerable<Item> Sort()
        {
            return from grouping in mapping
                   let item = grouping.Key
                   where item.ParentID == null
                   orderby item.CreateDate
                   from child in YieldItemAndChildren(item)
                   select child;
        }
    }
