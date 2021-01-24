    app.UseCors(builder =>
        builder.SetIsOriginAllowed(MyIsOriginAllowed) 
               .AllowAnyHeader()
               .AllowAnyMethod());
    // ...
    private static bool MyIsOriginAllowed(string origin)
    {
        var isAllowed = false;
        // Your logic.
        return isAllowed;
    }
