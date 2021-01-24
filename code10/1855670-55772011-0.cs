            services.AddScoped(factory =>
            {
                return new QueryFactory
                {
                    Compiler = new SqlServerCompiler(),
                    Connection = new SqlConnection(connStr),
                    Logger = compiled => Console.WriteLine(compiled)
                };
            });
