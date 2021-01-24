    [HttpGet("{searchText}/{filterType}")] 
    public async Task<ActionResult<List<Stock>>> Get(string searchText, string filterType)
    {
        var stockViewQueryable = this._context.StockView;
    
        // w =>
    	var param = Expression.Parameter(typeof(StockItem), "w");
        // w.[filterType]
    	var left = Expression.Property(param, typeof(StockItem).GetProperty(filterType));
        // searchText
    	var right = Expression.Constant(searchText, typeof(string));
        // ==
    	var expression = Expression.MakeBinary(ExpressionType.Equal, left, right);
    
        // Where(w => (w.Property1 == "Item1Property1Value"))
    	var whereExpression = Expression.Call(
            typeof(Queryable),
		    "Where",
		    new Type[] { queryableStockView.ElementType },
		    queryableStockView.Expression,
		    Expression.Lambda<Func<StockItem, bool>>(expression, new ParameterExpression[] { param })
        );
									  
    	var filteredItems = queryableStockView.Provider.CreateQuery<StockItem>(whereExpression);
    
        var v = await filteredItems.ToListAsync();
    
        return this.Ok(v);
     }
