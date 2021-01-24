    //Startup.cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseStatusCodePagesWithReExecute("/error/", "?statusCode={0}");
        ...
    }
    
    //SomeController.cs
    public IActionResult Error(int? statusCode = null)
    {
        if(statusCode == 404) return new ObjectResult(new { message = "404 - Not Found" });
        ...
    }
