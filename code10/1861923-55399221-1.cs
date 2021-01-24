    protected virtual void RegisterDatabase(IServiceCollection services)
            {
                string mongoConnectionString = Configuration.GetConnectionString("DevCN");
                services.AddScoped<IMyDbProcessor, MyDbProcessor>(sp =>
                {
                    var mongoClient = new MongoClient(mongoConnectionString);
                    return new MyDbProcessor(mongoClient);
                });
            }
