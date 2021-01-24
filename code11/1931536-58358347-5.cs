    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class UriReferenceAttribute : System.Attribute
    {
    }
    public sealed class UriReferenceGenerationProvider : PropertyCustomizationGenerationProvider
    {
        public const string UriReference = "uri-reference";
        public const string Uri = "uri";
        protected override JSchema Customize(JSchemaTypeGenerationContext context, JsonObjectContract contract, Type type, JSchema schema)
        {
            foreach (var property in contract.Properties.Where(p => p.PropertyType == typeof(Uri) && p.AttributeProvider.GetAttributes(typeof(UriReferenceAttribute), true).Any()))
            {
                JSchema propertySchema;
                if (!schema.Properties.TryGetValue(property.PropertyName, out propertySchema))
                    continue;
                propertySchema.Format = UriReference;
            }
            return schema;
        }
    }
