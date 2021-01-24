    public class SqlServerCustomTypeOptionsExtension : IDbContextOptionsExtensionWithDebugInfo
    {
        public string LogFragment => "using CustomTypes";
        public bool ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServerCustomTypes();
            return false;
        }
        public long GetServiceProviderHashCode() => 0;
        public void PopulateDebugInfo(IDictionary<string, string> debugInfo) 
            => debugInfo["SqlServer:" + nameof(SqlServerCustomDbContextOptionsBuilderExtensions.UseCustomTypes)] = "1";
        public void Validate(IDbContextOptions options)
        {
        }
    }
