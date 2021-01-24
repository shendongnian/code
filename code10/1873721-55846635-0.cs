    var corsOriginsSection = Configuration.GetSection("CorsOrigins");
    var origins = corsOriginsSection.Get<CorsOrigins>();
    
    services.AddCors(options => options.AddPolicy("AllowSpecificOrigin", p => p.WithOrigins(origins.Urls)
                                                   .AllowAnyMethod()
                                                   .AllowAnyHeader()));
