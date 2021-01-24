        public void ConfigureServices(IServiceCollection services)
            {
                var connection = @"Server=(JKCS-AREBY\SQLEXPRESS)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0";
                services.AddDbContext<TodoContext>(options => options.UseSqlServer(connection));
     services.AddMvc()
            }
