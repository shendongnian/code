public class ODataTypeSchemaFilter : ISchemaFilter
{
   private const string propToRename = "sub_AssignedToCompanyId@odata.bind";
   public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type, type)
   {
      if (type == typeof(MyObject))
      {
         // adding new schema property, and removing the old one
         schema.properties.Add(nameof(MyObject.AssignedToCompany), schema.properties[propToRename]);
         schema.properties.Remove(propToRename);
      }
   }
}
public class MyObject
{
   [JsonProperty(PropertyName = "sub_AssignedToCompanyId@odata.bind")]
   public int AssignedToCompany { get; set; }
}
This is a powerful feature, changing the schema could potentially cause other problems if not done properly. See Swagger documentation for more info.  I've used all three in my experience, just find which suits your needs best.
