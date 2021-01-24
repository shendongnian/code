    string path = Directory.GetCurrentDirectory(); 
    
      services.AddDbContext<MvcMusicStoreContext>(options =>
                      options.UseSqlServer(Configuration.GetConnectionString("MvcMusicStoreContext")
                      .Replace("[DataDirectory]",path)));
