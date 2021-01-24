    var ids = personModel.Select(x => x.PersonID);
    
    var results = findPersonResultsViewModel.Where(x => ids.Contains(x.PersonID));
    
    foreach (var item in results)
    {
       item.ActionType = true;       
       item.ExistInContactManager = true
    }
    db.SaveChanges();
