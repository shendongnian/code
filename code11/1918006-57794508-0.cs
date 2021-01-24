c#
public class MyFilter : IOperationFilter
{
 public void Apply(OpenApiOperation operation, OperationFilterContext context)
 {
   var myObjectSchema = context.SchemaGenerator.GenerateSchema(typeof(MyObject), context.SchemaRepository);
   operation.Parameters.Add(new OpenApiParameter
   {
    Name = "MyParameter",
    Description = "MyDescription"
    In = ParameterLocation.Header
    Required = true,
    Schema = myObjectSchema
   }
  }
}
