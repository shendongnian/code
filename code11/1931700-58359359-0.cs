    public static IServiceCollection AddAssetsSecure(
            this IServiceCollection services, Action<IdentityOptions> identity = default)
    {
         return services.AddAssetsIdentity(identity ?? ( _ => {}));
    }
