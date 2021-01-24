    public static class ServiceCollectionExtensions {
        public static void GetPersonalisationFeature(this IServiceCollection serviceCollection, IConfiguration config) {
            config.ThrowIfNull(nameof(config));
        
            serviceCollection.AddScoped<IMapToNew<Personalisation, PersonalisationState>, PersonalisationToPersonalisationState>();
            serviceCollection.AddScoped<IPersonalisationService, PersonalisationBogusService>();
        }
    }
