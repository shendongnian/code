    public IHttpActionResult InsertData([FromBody] dynamic model)
    {
        Type t = resolve type base on context information
        var method = this.GetType().GetMethod(nameof(InsertDataPrivate),
            BindingFlags.NonPublic | BindingFlags.Instance);
        var result = (int)GetDataMethodInfo.MakeGenericMethod(t)
           .Invoke(this, new object[] { queryOptions });
        
        return Ok(result);
    }
    private int InsertDataPrivate<T>(T model) where T
    {
        //Write the generic code here, for example:
        dbContext.Set<T>().Add(model);
        dbContext.SaveChanges();
        return some value;
    }
