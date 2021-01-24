csharp
[AttributeUsage(AttributeTargets.Method)]
public sealed class SwaggerParameterAttribute : Attribute
{
    public SwaggerParameterAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Type { get; set; } = "text";
    public bool Required { get; set; } = false;
}
2. Add a filter to handle the new attribute:
csharp
public class SwaggerParameterOperationFilter : IOperationFilter
{
    public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
    {
        var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerParameterAttribute>();
        if (requestAttributes.Any())
        {
            operation.parameters = operation.parameters ?? new List<Parameter>();
            foreach (var attr in requestAttributes)
            {
                operation.parameters.Add(new Parameter
                {
                    name = attr.Name,
                    description = attr.Description,
                    @in = attr.Type == "file" ? "formData" : "body",
                    required = attr.Required,
                    type = attr.Type
                });
            }
            if (requestAttributes.Any(x => x.Type == "file"))
            {
                operation.consumes.Add("multipart/form-data");
            }
        }
    }
}
3. Update your Swagger configuration to use the filter:
csharp
config.EnableSwagger(c =>
{
    c.OperationFilter<SwaggerParameterOperationFilter>();
    // ....
}
4. Add the attribute to your controller endpoint:
csharp
[HttpPost]
[SwaggerParameter("profilePicture", "A file", Required = true, Type = "file")]
public async Task<IHttpActionResult> Adduser([FromBody]User user)
{
//...
}
----------
Adapted from the following [blogpost][1].
  [1]: https://tahirhassan.blogspot.com/2017/12/web-apiswagger-file-upload.html
