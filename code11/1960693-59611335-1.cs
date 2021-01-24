    public async Task InvokeAsync(HttpContext httpContext)
    {
        //Instead of this
        var value = httpContext.Request.RouteValues["paramToCheck"];
       //Use like this
        string originalPath = context.Request.Path.ToString();
       //You will get your desired values to check your validation
       //and then
      //just check like this
     if (originalPath.Trim().Contains("api/URL/{paramToCheck}", 
         StringComparison.InvariantCultureIgnoreCase)
     //then do your necessary validation here
          
          
