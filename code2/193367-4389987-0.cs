    bool hitSubmitChanges = false;
    int changeCount = 0;
    IList<object> updates = null;
     
    // more code here... 
       // redirect DataContext.SubmitChanges() to a lambda to catch updates 
       MDataContext.AllInstances.SubmitChanges = (c) =>
       {
        changeCount = c.GetChangeSet().Updates.Count;
        updates = c.GetChangeSet().Updates;
        hitSubmitChanges = true;
       };
