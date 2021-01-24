    services.AddIdentityServer().AddMongoRepository()
                    .AddMongoDbForAspIdentity<ApplicationUser, IdentityRole> 
                     (Configuration)
                    .AddClients()
                    .AddIdentityApiResources()
                    .AddPersistedGrants()
                    .AddDeveloperSigningCredential()
                    .AddProfileService<ProfileService>();
