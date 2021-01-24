        public void ConfigureServices(IServiceCollection services)
        {                    
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True")); //Copied from Server explorer properties.
            services.AddScoped<IGenericRepository<MyModel>, GenericRepository<MyModel>>();
            services.AddScoped<IMyDbContext, MyDbContext>();
        }
