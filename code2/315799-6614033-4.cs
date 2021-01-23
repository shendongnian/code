    {
        collection1.InsertItem(item);  // item parent now == collection1
        collection2.InsertItem(item);  // fails, but I can get around it:
        item.BecomeOrphan(collection1); // item parent now == null 
        collection2.InsertItem(item);  // collection2 hijacks item by changing its parent (and exists in both collections)
    }
