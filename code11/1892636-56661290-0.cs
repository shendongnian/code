        app.UseAuthentication();
        app.Map("/dexml", subApp => {
            subApp.Use(async (context, next) =>
            {                    
                await next();
                var userName = context?.User?.Identity?.Name;
                if (userName != null)
                {
                    var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();
                    var user = dbContext.Users.FirstOrDefault(u => u.UserName == userName);
                    using (var provider = new PhysicalFileProvider($@"D:\{ user.Code1 }\{ user.Code2 }"))
                    {
                        var filePath = context.Request.Path.Value.TrimStart('/');
                        var info = provider.GetFileInfo(filePath);
                        using (var stream = info.CreateReadStream())
                        {
                            var originalStream = context.Response.Body;
                            await stream.CopyToAsync(originalStream);
                            context.Response.Body = stream;
                        }
                    }
                }
            });
        });
