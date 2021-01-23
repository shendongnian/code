    MethodCallExpression collectionCallExpression = 
    	Expression.Call(
    		typeof(Enumerable),
    		"DefaultIfEmpty",
    		new System.Type[]
    		{
    			typeof(DataObjectField)
    		},
    		Expression.Property(collectionParameter, newResultType.GetProperty("DataObjectFields"))
