public class IDInformation
{
    public int Id { get; set; }
}
Then deserialize like so:
var details = JsonConvert.DeserializeObject<List<IDInformation>>(File);
Note how the field name `Id` matches the Json `Id` field.
