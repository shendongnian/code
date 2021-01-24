    // You could build a Where string that can be converted to linq.
    // and do if sats and append your where sats string. as the example below
    var query = "c => (c.Field1 == \" a \" && c.Field2 == Y) || (c.Field3 == \" b \")";
    var indicator = query.Split('.').First(); // the indicator eg c
       // assume TABLE is the name of the class
    var p = Expression.Parameter(typeof(TABLE), indicator);
    var e = DynamicExpression.ParseLambda(new[] { p }, null, query);
    
    // and simple execute the expression 
    var items = Object.Where(e);
