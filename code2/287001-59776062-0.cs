    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method.Equals(HttpMethods.Get, StringComparison.OrdinalIgnoreCase))
        {
            …
        }
    }
