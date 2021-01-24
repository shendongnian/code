    public int CountActiveSocios()
    {
       IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
       var connectionString = configuration.GetConnectionString("local");
       var options = new DbContextOptionsBuilder<yangsoftDBContext>()
                        .UseSqlServer(new SqlConnection(connectionString))
                        .Options;
        using (var context = new yangsoftDBContext(options)) // <-- Pass the options here
        {
           try
           {
               return context.Socios.Where(r => r.Estado == true).Count();
           }
           catch
           {
              return 0;
           }
        }
    }
