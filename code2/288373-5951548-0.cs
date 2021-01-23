    var changes = DbContext.GetChangeSet();
    if(changes.Updates.Contains(EntityToCheck))
      //Changed state
    else if(changes.Inserts.Contains(EntityToCheck))
      //New state
    else if(changes.Deletes.Contains(EntityToCheck))
      //Delete state
