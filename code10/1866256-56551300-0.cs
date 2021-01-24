    services.AddDbContextPool<AppDbContext>
                (
                    dbContextOptionsBuilder =>
                    {
                      
                        dbContextOptionsBuilder.UseSqlServer("yourConnection",
                            optionsSqlServer => { optionsSqlServer.MigrationsAssembly("ADD_YOUR_ASSEMBLY_NAME");});
                       
                    }
                );
