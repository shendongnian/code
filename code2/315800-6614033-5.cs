    {
        collection1.InsertItem(item);  // item parent now == collection1
        collection2.InsertItem(item);  // fails, so...
        item.BecomeOrphan(????); // can't do it because I don't know the guid, only collection1 knows it.
    }
