    //var act = ActivityList.Where(a => a.Id == GuidToCompare).SingleOrDefault(); // clearer
    var act = ActivityList.SingleOrDefault(a => a.Id == GuidToCompare);          // shorter
    if (act != null)
    {
        //Code here
    }
