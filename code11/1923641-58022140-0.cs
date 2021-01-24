    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = async ctx =>
        {
            var request = ctx.Context.Request;
            string index = "";
            if (request.Host.Host.Equals("app.domain.com") && request.Path.Value.Contains("index.html"))
            {
                index = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "PublicIndex.html");
            }
            else if (request.Host.Host.Equals("admin.domain.com") && request.Path.Value.Contains("index.html"))
            {
                index = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "PrivateIndex.html");
            }
            if (!String.IsNullOrEmpty(index))
            {
                var fileBytes = File.ReadAllBytes(index);
                ctx.Context.Response.ContentLength = fileBytes.Length;
                using (var stream = ctx.Context.Response.Body)
                {
                    await stream.WriteAsync(fileBytes, 0, fileBytes.Length);
                    await stream.FlushAsync();
                }
            }
        }
    });
