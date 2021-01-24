    [ResponseType(typeof(AnyTypeResponse))]
    [HttpPost]
    public async Task<IHttpActionResult> MyAPI()
    {
        var res = await MyFuncTree1();
        return Ok(res);
    }
    
    public Task<AnyTypeResponse> MyFuncTree1()
    {
        return  MyFuncTree2();
    }
    
    public Task<AnyTypeResponse> MyFuncTree2()
    {
        return MyFuncTree3();
    }
    
    public Task<AnyTypeResponse> MyFuncTree3()
    {
        return CallExternalService();
    }
