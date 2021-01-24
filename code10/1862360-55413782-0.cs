c#
internal class ApplyRequiredAttributeFilter : IOperationFilter
{
  public void Apply( Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription )
  {
    HttpParameterBinding[] parameterBindings = apiDescription.ActionDescriptor.ActionBinding.ParameterBindings;
    foreach ( HttpParameterBinding binding in parameterBindings ) {
      PropertyInfo[] properties = binding.Descriptor.ParameterType.GetProperties();
      // If the type is not an object and has no properties, ignore it.
      if ( properties.Length == 0 ) {
        continue;
      }
      Parameter modelParamater = operation.parameters.Last();
      if ( modelParamater == null ) {
        continue;
      }
      string schemaPath = modelParamater.schema?.@ref;
      string schemaName = schemaPath?.Split( '/' ).Last();
      if ( schemaName == null ) {
        continue;
      }
      Schema oldSchema = schemaRegistry.Definitions[ schemaName ];
      // Copy the existing schema.
      Schema newSchema = new Schema
      {
        description = oldSchema.description,
        properties = new Dictionary<string, Schema>( oldSchema.properties ),
        required = oldSchema.required != null ? new List<string>( oldSchema.required ) : new List<string>(),
        @type = oldSchema.type,
        vendorExtensions = new Dictionary<string, object>( oldSchema.vendorExtensions )
      };
      // Find model properties with the custom attribute.
      foreach ( PropertyInfo property in properties ) {
        ApiRequiredAttribute attribute = property.GetCustomAttribute<ApiRequiredAttribute>();
        if ( attribute != null ) {
          // If the model property is required in POST/PUT and current HTTP method is POST/PUT
          // Add the property to the new schema's required flags.
          if ( attribute.RequiredInPut && apiDescription.HttpMethod.Method.Equals( "PUT" ) ||
               attribute.RequiredInPost && apiDescription.HttpMethod.Method.Equals( "POST" ) ) {
            newSchema.required.Add( property.Name );
            string newSchemaName = $"{schemaName}:{apiDescription.HttpMethod.Method}";
            if ( !schemaRegistry.Definitions.ContainsKey( newSchemaName ) ) {
              schemaRegistry.Definitions.Add( newSchemaName, newSchema );
            }
            // Change the current model schema reference to the new schema with the addition required flags.
            modelParamater.schema.@ref = $"{schemaPath}:{apiDescription.HttpMethod.Method}";
          }
        }
      }
    }
  }
}
I then addd the filter to my EnableSwagger call.
c#
GlobalConfiguration.Configuration
                   .EnableSwagger("docs/swagger/", c =>
                                    {
                                      // Other initialization code... 
                                      c.OperationFilter<ApplyRequiredAttributeFilter>();
                                    });
The attributes are used like so:
c#
[ApiRequired( RequiredInPost = true, RequiredInPut = true)]
public bool? Active
{
  get;
  set;
}
[ApiRequired( RequiredInPost = true )]
public string UserName
{
  get;
  set;
}
Finally, on the docs, the required flags look like this. The POST method parameters are on the left while the PUT method paramaters are on the right:
[![enter image description here][1]][1]
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/i3mVd.png
  [2]: https://i.stack.imgur.com/vVNO7.png
