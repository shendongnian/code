        foreach (Tree item in list)
            {
                if (lookup.ContainsKey((int)item.ParentId))
                {
       var collection = lookup[(int)item.ParentId].w2ui?? new Collections();
       collection.child.Add(item);
                    // add to the parent's child list 
                    lookup[(int)item.ParentId].w2ui = collection;
                }
                else
                {
                    // no parent added yet (or this is the first time)
                    nested.Add(item);
                }
                lookup.Add(item.Id, item);
            }
