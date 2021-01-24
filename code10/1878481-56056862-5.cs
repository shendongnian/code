    if (context.Request.HasFormContentType)
    {
        IFormCollection form;
        form = context.Request.Form; // sync
        // Or
        form = await context.Request.ReadFormAsync(); // async
        string param1 = form["param1"];
        string param2 = form["param2"];
     }
