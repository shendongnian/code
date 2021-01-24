    public IHttpActionResult InsertData([FromBody] dynamic model)
    {
        Type t = resolve type base on context information
        object data = create an instance of t base on the model values;
        var method = this.GetType().GetMethod(nameof(InsertDataPrivate),
            BindingFlags.NonPublic | BindingFlags.Instance);
        var result = (int)method.MakeGenericMethod(t)
           .Invoke(this, new object[] { data });
        
        return Ok(result);
    }
    private int InsertDataPrivate<T>(T model) where T
    {
        //Write the generic code here, for example:
        dbContext.Set<T>().Add(model);
        dbContext.SaveChanges();
        return some value;
    }
