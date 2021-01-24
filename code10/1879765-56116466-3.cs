    using (var context = serviceProvider.GetService<BloggingContext>())
    {
      // do stuff
    }
    var options = serviceProvider.GetService<DbContextOptions<BloggingContext>>();
