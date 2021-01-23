    DBEntities db = new DBEntities();
    IEnumerable<Action> query = 
                from action in db.Action
                where action.TimeOfAction > new DateTime(2010, 11, 1, 0, 0, 0)
                where action.TimeOfAction < new DateTime(2011, 2, 7, 0, 0, 0)
                where action.EntityName == "seant"
                select action;
    var count = query.Select(x => x.TimeOfAction).Distinct().Count();
    // Use query here as well to get at full action details
