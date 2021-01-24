    public static class SqlServerCustomDbContextOptionsBuilderExtensions
    {
        public static object UseCustomTypes(this SqlServerDbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) throw new ArgumentNullException(nameof(optionsBuilder));
            // Registere die SqlServerDiamantOptionsExtension.
            var coreOptionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure)optionsBuilder).OptionsBuilder;
            var extension = coreOptionsBuilder.Options.FindExtension<SqlServerCustomTypeOptionsExtension>()
                ?? new SqlServerCustomTypeOptionsExtension();
            ((IDbContextOptionsBuilderInfrastructure)coreOptionsBuilder).AddOrUpdateExtension(extension);
            // Configure Warnings
            coreOptionsBuilder
                .ConfigureWarnings(warnings => warnings
                    .Log(RelationalEventId.QueryClientEvaluationWarning)        // Should be thrown to prevent only warnings if a query is not fully evaluated on the db
                    .Ignore(RelationalEventId.ValueConversionSqlLiteralWarning));  // Ignore warnings for types that are using a ValueConverter
            return optionsBuilder;
        }
    }
     public static class SqlServerServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkSqlServerCustomTypes(
            this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAddProviderSpecificServices(
                    x => x.TryAddSingletonEnumerable<IRelationalTypeMappingSourcePlugin, SqlServerCustomTypeMappingSourcePlugin>()
                          .TryAddSingletonEnumerable<IMemberTranslatorPlugin, SqlServerCustomTypeMemberTranslatorPlugin>()
                          .TryAddSingletonEnumerable<IMethodCallTranslatorPlugin, SqlServerCustomTypeMethodCallTranslatorPlugin>());
            return serviceCollection;
        }
    }
