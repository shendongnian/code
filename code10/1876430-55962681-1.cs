         public static class EditorRCLServiceCollectionExtensions
        {
            public static void AddEditor(this IServiceCollection services)
            {
                services.ConfigureOptions(typeof(EditorRCLConfigureOptions));
            }
        }
