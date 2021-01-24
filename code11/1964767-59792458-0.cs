c#
services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme;
    });
to
c#
services.AddAuthentication(options =>
            {
                options.DefaultScheme = OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
            });
