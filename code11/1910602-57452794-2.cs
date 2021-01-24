		public void ConfigureServices(IServiceCollection services)
		{
			services
				.Configure<JwtIssuerOptions>(jwtIssuerOptionsConfig)
				.Configure<JwtIssuerOptions>(options =>
				{
					options.SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);
				});
			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.IncludeErrorDetails = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ClockSkew = TimeSpan.FromMinutes(5),
						IssuerSigningKey = symmetricSecurityKey,
						RequireSignedTokens = true,
						RequireExpirationTime = true,
						ValidateLifetime = true,
						ValidAudience = jwtIssuerOptions.Audience,
						ValidateIssuer = true,
						ValidIssuer = jwtIssuerOptions.Issuer
					};
					if (_isDevelopment)
					{
						options.Events = new JwtBearerEvents
						{
							OnAuthenticationFailed = c =>
							{
								Debug.WriteLine(c.Exception.Message);
								return Task.CompletedTask;
							},
						};
					}
				});
