cs
public class Deal
{
	public Deal()
	{
		PublicIds = new List<PublicId>();
	}
	public string Id { get; set; }
	public string Name { get; set; }
	public List<PublicId> PublicIds { get; set; }
}
public class PublicId
{
	public string IdType { get; set; }
	public string Value { get; set; }
}
Then in the console if the try the code below it seems to yield the desired result.
cs
public static void Main()
{
	var deal = new Deal();
	deal.Name = "Deal 1";
	deal.PublicIds.Add(new PublicId { IdType = "ID1", Value = "A12" });
	deal.PublicIds.Add(new PublicId { IdType= "ID2", Value= "B12"});
	var json = JsonConvert.SerializeObject(deal, Formatting.Indented, new JsonSerializerSettings
	{
		DateFormatString = "yyyy-MM-dd",
		ContractResolver = new CamelCasePropertyNamesContractResolver()
	});
	Console.WriteLine(json);
	Console.ReadLine();
}
Output by the code:
json
{
  "id": null,
  "name": "Deal 1",
  "publicIds": [
    {
      "idType": "ID1",
      "value": "A12"
    },
    {
      "idType": "ID2",
      "value": "B12"
    }
  ]
}
