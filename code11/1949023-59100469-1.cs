    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                   ....  
                    optionsBuilder.AddInterceptors(new CollationDbCommandInterceptor());
                    ....
                }
            }
