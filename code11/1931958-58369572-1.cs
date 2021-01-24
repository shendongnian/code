using Newtonsoft.Json.Linq;
(...)
JObject o = JObject.Parse(json);
var rs = o["results"];
foreach (var r in rs)
{
    Console.WriteLine("-----");
    Console.WriteLine(r);
}
# Output
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
 
