    public class AssignPropertyRequiredFilter : ISchemaFilter
        {
            public void Apply(Schema schema, SchemaFilterContext context)
            {
                var requiredProperties = context.SystemType.GetProperties()
                    .Where(x => x.IsDefined(typeof(NotNullAttribute)))
                    .Select(t => char.ToLowerInvariant(t.Name[0]) + t.Name.Substring(1));
    
                if (schema.Required == null)
                {
                    schema.Required = new List<string>();
                }
                schema.Required = schema.Required.Union(requiredProperties).ToList();
            }
        }
