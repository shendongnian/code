    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class UriReferenceAttribute : System.Attribute
    {
    }
    public sealed class UriReferenceGenerationProvider : SchemaCustomizationGenerationProvider
    {
        public const string UriReference = "uri-reference";
        public const string Uri = "uri";
        protected override bool CanCustomize(JSchemaTypeGenerationContext context, JsonContract contract, Type type) { return contract is JsonObjectContract; }
        protected override JSchema Customize(JSchemaTypeGenerationContext context, JsonContract contract, Type type, JSchema schema)
        {
            foreach (var property in ((JsonObjectContract)contract).Properties.Where(p => p.PropertyType == typeof(Uri) && p.AttributeProvider.GetAttributes(typeof(UriReferenceAttribute), true).Any()))
            {
                JSchema propertySchema;
                if (!schema.Properties.TryGetValue(property.PropertyName, out propertySchema))
                    continue;
                propertySchema.Format = UriReference;
            }
            return schema;
        }
    }
