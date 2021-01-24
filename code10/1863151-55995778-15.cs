    namespace TestIdentityServer4
    {
        public class Startup
        { 
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryApiResources(new List<ApiResource>()
                    {
                        //Api which returns redirect url with code and state.
                        new ApiResource("auth.api", "Auth API"),
                        //App1 api. Just to show that app1 has some functionality (IdentityController).
                        new ApiResource("app1.api", "App1 API"),
                        //This resource is authentification functionality implemented by AuthCodeValidator.
                        new ApiResource("code.authentication", "Authentication by code")
                    })
                    .AddInMemoryClients(new List<Client>()
                    {
                        //web app1
                        new Client
                        {
                            ClientId = "app1",
                            ClientSecrets =
                            {
                                new Secret("app1secret".Sha256())
                            },
                            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                            AllowedScopes =
                            {
                                "app1.api",
                                "auth.api"
                            },
                            AllowOfflineAccess = true
                        },
                        //web app2
                        new Client
                        {
                            ClientId = "app2",
                            ClientSecrets = new List<Secret>
                            {
                                new Secret("app2secret".Sha256())
                            },
                            AllowedGrantTypes = { "app2_auth_code" },
                            AllowedScopes = new List<string>
                            {
                                "code.authentication"
                            }
                        }
                    })
                    //App1 users for test purpose
                    .AddTestUsers( new List<TestUser>()
                    {
                        new TestUser()
                        {
                            Username = "tu1",
                            Password = "111111",
                            SubjectId = "tu1"
                        }
                    })
                    //Regestring of the custom validator
                    .AddExtensionGrantValidator<AuthCodeValidator>();
                //Our IS4 has the custom api (CodeAuthorityController). It is also a resorce that should be protected.
                //It should be awailable fore user authorized in app1.
                services.AddAuthentication(opt =>
                {
                    opt.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    opt.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                    .AddIdentityServerAuthentication(
                        opt =>
                        {
                            opt.Authority = "http://localhost:5000";
                            opt.RequireHttpsMetadata = false;
                            opt.ApiName = "auth.api";
                        });
                services.AddMvc();
            }
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseCors();
                app.UseIdentityServer();
                app.UseMvc();
            }
        }
    }
