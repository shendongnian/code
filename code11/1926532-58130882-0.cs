csharp
 public class Dto
{
	public string Name { get; set; }
	public string Address { get; set; }
}
static void Convert()
{
	var dto = new Dto { Name = "Name", Address = "Address" };
	var ta = TypeAccessor.Create(typeof(Dto));
	var oa = ObjectAccessor.Create(dto);
	var values = new Dictionary<string, AttributeValue>();
	foreach (var m in ta.GetMembers())
	{
		values.Add(m.Name, new AttributeValue { S = oa[m.Name].ToString() });
	}
}
`
