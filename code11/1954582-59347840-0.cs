    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BearerTokenFromHeaderAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
    {
        public BindingSource BindingSource => new BindingSource("BearerToken", "BearerToken", false, true);
        public string Name { get; set; }
    }
    public static class BearerTokenBindingSource
    {
        public static readonly BindingSource Instance = new BindingSource(
            "BearerToken",
            "BearerToken",
            isGreedy: false,
            isFromRequest: true);
    }
    public class BearerTokenValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            var authorizationHeader = context.ActionContext.HttpContext.Request.Headers["Authorization"];
            var accessToken = authorizationHeader[0].Replace("Bearer ", string.Empty);
            context.ValueProviders.Add(new BearerTokenValueProvider(BearerTokenBindingSource.Instance, accessToken));
            return Task.CompletedTask;
        }
    }
    public class BearerTokenValueProvider : BindingSourceValueProvider
    {
        public BearerTokenValueProvider(BindingSource bindingSource, string accessToken) : base(bindingSource)
        {
            AccessToken = accessToken;
        }
        private string AccessToken { get; }
        public override bool ContainsPrefix(string prefix)
        {
            return false;
        }
        public override ValueProviderResult GetValue(string key)
        {
            return new ValueProviderResult(AccessToken);
        }
    }
