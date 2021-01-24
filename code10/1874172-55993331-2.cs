            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ...
            services.AddDbContext<BloggingContext>(options =>
            {
                var customerId = serviceProvider.GetService<IHttpContextAccessor>().HttpContext?.User?.FindFirst("customerId")?.Value;
                var connectionString = 
                    $"bla blah blah ;Initial Catalog={customerId}";
                options.UseSqlServer(connectionString);
