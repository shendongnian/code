            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "RBFirmware")),
                RequestPath = "/File",
                OnPrepareResponse = context => {                    
                    Console.WriteLine($"downloading -- {context.File.Name}");
                }
            });
