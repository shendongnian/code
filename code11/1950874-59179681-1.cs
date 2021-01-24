    app.UseWhen(context => context.Response.ContentType == "text/html", subApp => subApp.Use(async (context, next) =>
    {
        var body = context.Response.Body;
        using (var updatedBody = new MemoryStream())
        {
            context.Response.Body = updatedBody;
            await next();
            context.Response.Body = body;
            updatedBody.Seek(0, SeekOrigin.Begin);
            var newContent = new StreamReader(updatedBody).ReadToEnd();
            // Replace content here ...
            await context.Response.WriteAsync(newContent);
        }
    }));
