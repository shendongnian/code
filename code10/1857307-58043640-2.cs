    public class SwaggerAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.deprecated |= apiDescription.IsDeprecated();
            if (operation.parameters == null)
            {
                return;
            }
            if (operation.parameters != null)
            {
                foreach (var parameter in operation.parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.name);
                    if (parameter.description == null)
                    {
                        parameter.description = description.Documentation;
                    }
                    if (parameter.@default == null)
                    {
                        parameter.@default = description.ParameterDescriptor?.DefaultValue;
                    }
                }
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    @default = "Bearer ",
                    description = "Access token for the API",
                    required = false,
                    type = "string"
                });
            }
        }
    }
