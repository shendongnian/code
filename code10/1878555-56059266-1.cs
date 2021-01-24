    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("<connection string>")
            .ConfigureWarnings(warnings => 
                warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
    }
