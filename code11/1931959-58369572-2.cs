public class X {
	public List<string> HtmlAttributions { get; set; }
	public List<Result> Results { get; set; }
}
public class Result
{
   public List<string> Types { get; set; }
   public string Vicinity { get; set; }
}
(...)
var settings new JsonSerializerSettings
{
    ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy()}});
var x = JsonConvert.DeserializeObject<X>(json, settings); 
Console.WriteLine(x.Results[0].Types[1]);
Console.WriteLine(x.Results[0].Vicinity);
## Output
political
Oakville
# B. JObject.Parse
## Code 
using Newtonsoft.Json.Linq;
(...)
JObject o = JObject.Parse(json);
var rs = o["results"];
foreach (var r in rs)
{
    Console.WriteLine("-----");
    Console.WriteLine(r);
}
## Output
*Btw. The array in your json is not closed.*
-----
{
  "types": [
    "locality",
    "political"
  ],
  "vicinity": "Oakville"
}
-----
{
  "types": [
    "university",
    "point_of_interest",
    "establishment"
  ],
  "vicinity": "1430 Trafalgar Road, Oakville"
}
 
