    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents {
                OnTokenValidated = async context =>
                {                            
                    var accessToken = context.SecurityToken as JwtSecurityToken;
                    var dbContext = services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var tags = await dbContext.Tags.ToListAsync();
                    context.Fail("Token is invalid");
                    return;
                }
            };
        });
