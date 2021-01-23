    var AddedItems = NewList.Except(OldList);
    var RemovedItems = OldList.Except(NewList);
    var OldListLookup = OldList.ToLookup(t => t.Id);
    var ItemsInBothLists =
        from newThing in NewList
        let oldThing = OldListLookup[newThing.Id].FirstOrDefault()
        where oldThing != null
        select new { oldThing = oldThing, newThing = newThing };
