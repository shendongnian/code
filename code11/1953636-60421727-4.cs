     public virtual IdentityBuilder AddTokenProvider(string providerName, Type provider)
            {
                if (!typeof(IUserTwoFactorTokenProvider<>).MakeGenericType(UserType).GetTypeInfo().IsAssignableFrom(provider.GetTypeInfo()))
                {
                    throw new InvalidOperationException(Resources.FormatInvalidManagerType(provider.Name, "IUserTwoFactorTokenProvider", UserType.Name));
                }
                Services.Configure<IdentityOptions>(options =>
                {
                    options.Tokens.ProviderMap[providerName] = new TokenProviderDescriptor(provider);
                });
                Services.AddTransient(provider);
                return this;
            }
