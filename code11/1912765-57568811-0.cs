    [EnableQuery]
    public IHttpActionResult Get()  
    {  
        var result = GetData().AsQueryable();  
        return Ok(result);  
    }  
