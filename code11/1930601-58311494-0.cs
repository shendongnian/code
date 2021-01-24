c#
builder.Services.AddTransient<ISchemaMapper>(_ => new SchemaMapper(new Dictionary<string,ISchema> {
{"SchemaOne", new SchemaOne(new FuncDependencyResolver(type => (IGraphType)_.GetRequiredService(type))) },
{"SchemaTwo", new SchemaTwo(new FuncDependencyResolver(type => (IGraphType)_.GetRequiredService(type))) } }));
**Interface Used**
c#
public interface ISchemaMapper
{
  ISchema GetSchema(string schema);
}
**Implementation of interface**
c#
public class SchemaMapper : ISchemaMapper
{
   public Dictionary<string, ISchema> mappedSchema;
   public SchemaMapper(Dictionary<string, ISchema> mappedSchemas)
   {
      this.mappedSchema = mappedSchemas;
   }
   public ISchema GetSchema(string schema)
   {
      return mappedSchema[schema];
   }
}
At this point in time it is a hacky way around conflicting dependency injections, but I will update if I either find a better way or it is chugging along strong in the future. 
