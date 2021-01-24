    services.AddCors(options =>
    {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());
    });
