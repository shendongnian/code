    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.Value.Contains("api/webhook"))
        {  
            if (context.Request.ContentType == "multipart/form-data")
                context.Request.Headers.Remove("Content-Type");            
        }
  
        await _next.Invoke(context);
    }
