cs
void Main()
{
	var json = json_from_api;
	var results = JsonConvert.DeserializeObject<RootObject>(json);
	var groupedResults = results.value.GroupBy(r => new { r.id, r.name, r.grade });
	var finalResults = groupedResults.Select(g => new
	{		
			g.Key.id,
			g.Key.name,
			g.Key.grade,
			test_results = g.ToList().Select(v => new
			{
				v.TestID,
				v.testResult
			}
	)});
	
	var output = new {
		value = finalResults
	};
	Console.WriteLine(JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented));
}
public class Value
{
	public string name { get; set; }
	public string id { get; set; }
	public int grade { get; set; }
	public string TestID { get; set; }
	public string testResult { get; set; }
}
public class RootObject
{
	public List<Value> value { get; set; }
}
Output:
json
{
  "value": [
    {
      "id": "12345",
      "name": "russ",
      "grade": 5,
      "test_results": [
        {
          "TestID": "12332",
          "testResult": "Pass"
        },
        {
          "TestID": "15474",
          "testResult": "Pass"
        },
        {
          "TestID": "75783",
          "testResult": "Fail"
        }
      ]
    }
  ]
}
