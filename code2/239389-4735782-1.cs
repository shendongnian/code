    var lstObjects = new List<object>();
    var query = "Phase = @0 ";
    lstObjects.Add(Phase.Value);
    for (int i = 1; i < Phase.Count; i++)
    { 
        query += string.Format(" || Phase == @{0}", i);
    }
    
    context.myList.Where(query,lstObjects.ToList());
