      public void ConfigureSwagger(IApplicationBuilder app)
      {
          const string swagger = "Swagger";
          var directory = Path.Combine(Directory.GetCurrentDirectory(), swagger);
          Directory.CreateDirectory(directory);
          app.UseDefaultFiles().UseStaticFiles(new StaticFileOptions
          {
              FileProvider = new PhysicalFileProvider(directory),
              RequestPath = $"/{swagger}"
          });
          app.UseSwaggerUI(c =>
          {
              foreach (var document in Assembly.GetExecutingAssembly().CreateDocuments("title", "description", "name", "email"))
              {
                  var file = $"swagger{document.Info.Version}.json";
                  File.WriteAllText(Path.Combine(directory, file), document.ToJson());
                  c.SwaggerEndpoint($"/{swagger}/{file}", $"{document.Info.Title} {document.Info.Version}");
              }
          });
      }
