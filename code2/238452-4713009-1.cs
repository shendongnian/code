    public IQueryable<Approved> ReturnRecordsByObjectiveFlag(string columnName)
    {   
        var param = Expression.Parameter(typeof(Approved), "x");
        var predicate = Expression.Lambda<Func<Approved,bool>>(
            Expression.Equal(
                Expression.PropertyOrField(param, columnName),
                Expression.Constant("Y")
            ), param);
        return db.Approved.Where(predicate);
    }
