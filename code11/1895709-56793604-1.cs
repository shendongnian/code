    public static class WebHostExtensions{
       public static IWebHost InitDataBase(this IWebHost host){
           using (var scope = host.Services.CreateScope())
           {
               var services = scope.ServiceProvider;
               dbContext = services.GetService<YourDbContext>();
               // your code here
           }
       }
    }
