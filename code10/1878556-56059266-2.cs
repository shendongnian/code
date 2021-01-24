    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        options.ConfigureWarnings(warnings => 
            warnings.Throw(RelationalEventId.QueryClientEvaluationWarning);
    });
