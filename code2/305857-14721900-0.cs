    internal class CustomDataServiceContext : DataServiceContext
    {
        public CustomDataServiceContext(Uri serviceRoot)
        : base(serviceRoot, DataServiceProtocolVersion.V3)
        {
            this.ResolveName = ResolveNameFromType;
            this.ResolveType = ResolveTypeFromName;
        }
	
        protected string ResolveNameFromType(Type clientType)
        {
            if (clientType.Namespace.Equals("ODataClient.MSProducts", StringComparison.Ordinal))
            {
                return string.Concat("ODataService.Models.", clientType.Name);
            }
            return clientType.FullName;
        }
        protected Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("ODataService.Models", StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("ODataClient.MSProducts", typeName.Substring(19)), false);
            }
            return null;
        }
    }
