    public class SwaggerExcludeFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (!apiDescription.GetControllerAndActionAttributes<ReturnShortModelAttribute>().Any())
            {
                return;
            }
            var responseType = apiDescription.ResponseDescription.DeclaredType;
            var description = $"OK (uses a short model of {responseType})";
            var props = responseType
                        .GetProperties()
                        .Where(p => p.GetCustomAttributes(typeof(ShortModelMemberAttribute)).Any())
                        .ToDictionary(p => p.Name, p.PropertyType.Name);
            }
    
            operation.responses.Clear();
            operation.responses.Add("200", new Response
            {
                description = description,
                schema = new Schema
                {
                    example = props,
                },
            });
        }
    }   
