    public static IdentityBuilder AddDefaultTokenProviders(this IdentityBuilder builder)
            {
                var userType = builder.UserType;
                var dataProtectionProviderType = typeof(DataProtectorTokenProvider<>).MakeGenericType(userType);
                var phoneNumberProviderType = typeof(PhoneNumberTokenProvider<>).MakeGenericType(userType);
                var emailTokenProviderType = typeof(EmailTokenProvider<>).MakeGenericType(userType);
                var authenticatorProviderType = typeof(AuthenticatorTokenProvider<>).MakeGenericType(userType);
                return builder.AddTokenProvider(TokenOptions.DefaultProvider, dataProtectionProviderType)
                    .AddTokenProvider(TokenOptions.DefaultEmailProvider, emailTokenProviderType)
                    .AddTokenProvider(TokenOptions.DefaultPhoneProvider, phoneNumberProviderType)
                    .AddTokenProvider(TokenOptions.DefaultAuthenticatorProvider, authenticatorProviderType);
        }
