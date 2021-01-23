    DBEntities db = new DBEntities();
    IQueryable<DateTime> query = 
                from action in db.Action
                where action.TimeOfAction > new DateTime(2010, 11, 1, 0, 0, 0)
                where action.TimeOfAction < new DateTime(2011, 2, 7, 0, 0, 0)
                where action.EntityName == "seant"
                select action.TimeOfAction;
    var count = query.Distinct().Count();
