       protected override async void Seed(ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
                   
            context.Test.AddOrUpdate(x => x.Id,
                     new Test() { Id = 1, Name = "Test" }
            );
            await context.SaveChangesAsync();
  
        }
