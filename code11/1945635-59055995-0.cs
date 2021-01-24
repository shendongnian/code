    //This string is for the named policy, discussed in the link above:
    readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    public void ConfigureServices(IServiceCollection services) {
       services.AddControllers();
       services.AddSignalR();
       services.AddCors(options =>
       {
           options.AddPolicy(MyAllowSpecificOrigins,
           builder => {
               //URLs are from the front-end (note that they changed
               //since posting my original question due to scrapping
               //the original projects and starting over)
               builder.WithOrigins("https://localhost:44323", "http://localhost:51263")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
           });
       });
    }
