    if (httpContext.Request.HasFormContentType)
    {
        IFormCollection form;
        form = httpContext.Request.Form; // sync
        // Or
        form = await httpContext.Request.ReadFormAsync(); // async
        string param1 = form["param1"];
        string param2 = form["param2"];
     }
