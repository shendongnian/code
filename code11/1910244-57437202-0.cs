    public void Configure(
        IApplicationBuilder app, 
        IServiceProvider services) // <- magic here
    {
       // ...
       SeedData.SeedDatabase(services);
    }
    
    public class SeedData
    {
        public static void SeedDatabase(IServiceProvider services)
        {
            PwdrsDbContext context = services.GetRequiredService<PwdrsDbContext>();
        }
    }
