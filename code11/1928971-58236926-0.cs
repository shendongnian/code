        services.AddScoped<ICompanyType, CompanyType>();
        services.AddEntityFrameworkSqlServer();
        services.AddDbContext<CompanyDbContext>((serviceProvider, options) =>
            {
                var companyCode = serviceProvider.GetRequiredService<ICompanyType>().Get();
                string connectionString = string.Empty;
                switch (companyCode)
                {
                    case CompanyType.HKG:
                        connectionString = Configuration.GetConnectionString("HkgCompanyDbConnection");
                        break;
                    case CompanyType.SHG:
                        connectionString = Configuration.GetConnectionString("ShgCompanyDbConnection");
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                options
                    .UseSqlServer(connectionString)
                    .UseInternalServiceProvider(serviceProvider);
            });
         
