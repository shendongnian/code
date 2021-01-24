    public static class SeedInitializerExtensions
    {
        public static void UseSeedInitializer(this IApplicationBuilder app)
        {
            var service = app.ApplicationServices.GetRequiredService<SeedInitializer>();
                service.Seed().Wait();
        }
    }
