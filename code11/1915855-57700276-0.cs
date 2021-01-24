     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
        if (!optionsBuilder.IsConfigured)
        {         
         optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("MSSQL_CONN_STR");
        }
    }
