    // for each combination of ID1 and ID2
    // return the latest item from the 
    // most frequently-occuring quantity
    IEnumerable<MyEntity> GetLatestMaxByID(IEnumerable<MyEntity> list) {
        foreach (var group in list.GroupBy(x => new { x.ID1, x.ID2 }))
            yield return GetSingleItemForIDs(group);
    }
    // return the latest item from the 
    // most frequently-occuring quantity
    MyEntity GetSingleItemForIDs(IEnumerable<MyEntity> list) {
        MyEntity maxEntity = null;
        foreach (var x in list)
            if (maxEntity == null || (x.Quantity > maxEntity.Quantity && x.Date > maxEntity.Date))
                maxEntity = x;
        return maxEntity;
    }
