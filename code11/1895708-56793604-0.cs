    public static class WebHostExtensions{
       public static IWebHost InitDataBase(this IWebHost host){
           var services = scope.ServiceProvider;
           dbContext = services.GetService<YourDbContext>();
           // your code here
       }
    }
