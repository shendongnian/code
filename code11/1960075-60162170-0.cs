// Test class containing external enum.
public class Test
{
    [AutoIncrement]
    [PrimaryKey]
    public int? Id { get; set; }
    public ExternalEnum? EnumValue { get; set; }
}
// Use ExternalEnum type to get it's Assembly grab all export Enums.
IEnumerable<Type> types = typeof(ExternalEnum)
    .Assembly
    .GetExportedTypes()
    .Where(x => x.IsSubclassOf(typeof(Enum)));
// Loop through exported enums and add EnumAsIntAttribute.
foreach (Type type in types)
{
    type.AddAttributes(new EnumAsIntAttribute());
}
// Create Test table in DB.
db.CreateTableIfNotExists<Test>();
// Save to DB.
db.Save<Test>(new Test 
{ 
    EnumValue = ECodeTableNumbers.tbnumActionLocations
});
  [1]: https://docs.servicestack.net/reflection-utils
