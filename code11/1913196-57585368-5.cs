    void Main()
    {
    	var queryableRecords = Product.FetchQueryableProducts();
    
    	Expression expression = queryableRecords.OrderBy("Name");
    
    	var func = Expression.Lambda<Func<IQueryable<Product>>>(expression)
    						 .Compile();
    
    	func().Dump();
    }
    
    public class Product
    {
    	public int Id { get; set; }
    
    	public string Name { get; set; }
    
    	public static IQueryable<Product> FetchQueryableProducts()
    	{
    		List<Product> productList = new List<Product>()
    		{
    		  new Product {Id=1, Name = "A"},
    		  new Product {Id=1, Name = "B"},
    		  new Product {Id=1, Name = "A"},
    		  new Product {Id=2, Name = "C"},
    		  new Product {Id=2, Name = "B"},
    		  new Product {Id=2, Name = "C"},
    		};
    
    		return productList.AsQueryable();
    	}
    }
    
    public static class ExpressionTreesExtesion
    {
    	
    	public static Expression OrderBy(this IQueryable queryable, string propertyName)
    	{
    		var propInfo = queryable.ElementType.GetProperty(propertyName);
    
    		var collectionType = queryable.ElementType;
    
    		var parameterExpression = Expression.Parameter(collectionType, "g");
    		var propertyAccess = Expression.MakeMemberAccess(parameterExpression, propInfo);
    		var orderLambda = Expression.Lambda(propertyAccess, parameterExpression);
    		return Expression.Call(typeof(Queryable),
    							   "OrderBy",
    							   new Type[] { collectionType, propInfo.PropertyType },
    							   queryable.Expression,
    							   Expression.Quote(orderLambda));
    
    	}
    
    
    }
