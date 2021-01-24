    public class CustomNameSchema : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (schema?.Properties == null)
                {
                    return;
                }
                if (schema.Properties.Any())
                {
                    foreach (var propType in context.Type.GetProperties().Where(x => x.CustomAttributes != null && x.CustomAttributes.Any()))
                    {
                        var schemaProp = schema.Properties.FirstOrDefault(x => x.Key.Equals(propType.Name, StringComparison.InvariantCultureIgnoreCase));
                        string newName = propType.GetCustomAttribute<DataMemberAttribute>()?.Name;
                        if (string.IsNullOrEmpty(newName))
                            continue;
                        if (schemaProp.Value.Enum != null && schemaProp.Value.Enum.Any())
                        {
                            for (int i = 0; i < schemaProp.Value.Enum.Count; i++)
                            {
                                OpenApiString curr = schemaProp.Value.Enum[i] as OpenApiString;
                                var memberInfo = propType.PropertyType.GetMember(curr.Value).FirstOrDefault();
                                string newValue = memberInfo.GetCustomAttribute<EnumMemberAttribute>()?.Value;
                                if (string.IsNullOrWhiteSpace(newValue))
                                    continue;
                                OpenApiString newStr = new OpenApiString(newValue);
                                schemaProp.Value.Enum.Remove(curr);
                                schemaProp.Value.Enum.Insert(0, newStr);
                            }
                        }
                        var newSchemaProp = new KeyValuePair<string, OpenApiSchema>(newName, schemaProp.Value);
                        schema.Properties.Remove(schemaProp);
                        schema.Properties.Add(newSchemaProp);
                    }
                }
                var objAttribute = context.Type.GetCustomAttribute<DataContractAttribute>();
                if (objAttribute != default && objAttribute?.Name?.Length > 0)
                {
                    schema.Title = objAttribute.Name;
                }
            }
        }
