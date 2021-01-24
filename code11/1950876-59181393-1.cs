    app.Use(async (context, next) => {
    	var body = context.Response.Body;
    
    	using (var updatedBody = new MemoryStream()) {
    		context.Response.Body = updatedBody;
    
    		try {
    			await next();
    		} catch {
    			throw;
    		} finally {
    		    context.Response.Body = body;
            }
    
    		if (context.Response.StatusCode == 200 && context.Response.ContentType != null && context.Response.ContentType.Contains("text/html", StringComparison.InvariantCultureIgnoreCase)) {
    			updatedBody.Seek(0, SeekOrigin.Begin);
    
    			using (var reader = new StreamReader(updatedBody)) {
    				var newContent = reader.ReadToEnd();
    
    				// Replace content here
    
    				await context.Response.WriteAsync(newContent);
    			}
    		} else {
    			if (updatedBody.Length > 0)
    				await context.Response.Body.WriteAsync(updatedBody.ToArray());
    		}
    	}
    });
