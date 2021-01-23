    public IQueryable<Approved> ReturnRecordsByObjectiveFlag(string columnName)
    {
        var param = Expression.Parameter(typeof(Approved), "x");
        Expression prop;
        var predicate = Expression.Lambda<Func<Approved, bool>>(
            Expression.Equal(
                (prop = Expression.PropertyOrField(param, columnName)),
                Expression.Constant(prop.Type == typeof(string) ?
                    (object)"Y" : (object)'Y', prop.Type)
            ), param);
        return db.Approved.Where(predicate);
    }
