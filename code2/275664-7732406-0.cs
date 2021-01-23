    var query = ...;
    var search = "asdfasdf";
    var fields = new Expression<Func<MyEntity,string>>[]{ 
        x => x.Prop1, 
        x => x.Prop2, 
        x => x.Prop3 
    };
    var notFields = new Expression<Func<MyEntity,string>>[]{ 
        x => x.Prop4, 
        x => x.Prop5 };
	
    //----- 
    var paramx = Expression.Parameter(query.ElementType);
	
    //get fields to search for true
    var whereColumnEqualsx = fields
        .Select(x => Expression.Invoke(x,paramx))
        .Select(x => Expression.Equal(x,Expression.Constant(search)))
        //you could change the above to use .Contains(...) || .StartsWith(...) etc.
        //you could also make it not case sensitive by 
        //wraping 'x' with a .ToLower() expression call, 
        //and setting the search constant to 'search.ToLower()'
        .Aggregate((x,y) => Expression.And(x,y));
	
    //get fields to search for false
    var whereColumnNotEqualsx = notFields
        .Select(x => Expression.Invoke(x,paramx))
        .Select(x => Expression.NotEqual(x, Expression.Constant(search)))
        //see above for the different ways to build your 'not' expression,
        //however if you use a .Contains() you need to wrap it in an Expression.Negate(...)
        .Aggregate((x,y) => Expression.Or(x,y));
        //you can change Aggregate to use Expression.And(...) 
        //if you want the query to exclude results only if the 
        //search string is in ALL of the negated fields.
	
    var lambdax = Expression.Lambda(
        Expression.And(whereColumnEqualsx, whereColumnNotEqualsx), paramx);
    var wherex = Expression.Call(typeof(Queryable)
        .GetMethods()
        .Where(x => x.Name == "Where")
        .First()
        .MakeGenericMethod(query.ElementType),
	    query.Expression,lambdax);
    //create query
    var query2 = query.Provider.CreateQuery(wherex).OfType<MyEntity>();
