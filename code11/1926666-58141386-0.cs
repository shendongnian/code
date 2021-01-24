    public static Expression<Func<TEntity, bool>> BuildLambda<TEntity>(OBJTYPE obj) {
        // (TEntity table)
        var parmTable = Expression.Parameter(typeof(TEntity), "table");
    
        // table.ONEFIELD
        var prop1 = Expression.Property(parmTable, "ONEFIELD");
        // table.ONEFIELD == 1
        var equal1 = Expression.Equal(prop1, Expression.Constant(1));
    
        // table.People
        var prop2_1 = Expression.Property(parmTable, nameof(People));
        // table.People.CountryID
        var prop2_2 = Expression.Property(prop2_1, "CountryID");
        // table.People.CountryID == 6
        var equal2 = Expression.Equal(prop2_2, Expression.Constant(6));
    
        // table.ONEFIELD == 1 && table.People.CountryID == 6
        var finalBody = Expression.AndAlso(equal1, equal2);
    
        // table => table.ONEFIELD == 1 && table.People.CountryID == 6
        return Expression.Lambda<Func<TEntity, bool>>(finalBody, parmTable);
    }
