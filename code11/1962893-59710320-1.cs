var parsedData = JsonConvert.DeserializeObject<RootObject>(str).Results.GroupBy(x=> x.Category.First())
        .Select(x=>
            new {
                 name= x.Key,
                 data =  x.GroupBy(c=>c.Category.Last())
                           .Select(c=> new {value=c.Sum(f=>f.Cost),name=c.Key})
                });
Where RootObject is defined as
public class Result
{
    public string Description { get; set; }
    public double Cost { get; set; }
    public List<string> Category { get; set; }
}
public class RootObject
{
	[JsonProperty("results")]
    public List<Result> Results { get; set; }
}
**Part 2**
The second part has to be executed depended how you want the Json to be formated. If you observe the expected result given in OP, that doesn't look like a valid Json. Simplifying it for representational purposes, the Json string looks like following
{ 
 name : "Online", 
 data: [....],
 name : "Transport",
 data: [...],
}
As observed, the name and data fields are duplicated within json. If you would like to have result in this particular manner, you need to Serialize the Json recieved in **Part 1**, and modify it using string manipulation. For example,
var jsonCollection =  parsedData.Select(x=> Regex.Replace(JsonConvert.SerializeObject(x,Newtonsoft.Json.Formatting.Indented),@"^{|}$",string.Empty));
var finalResult = $"{{{string.Join(",",jsonCollection)}}}";
**Output**
{
  "name": "Online",
  "data": [
    {
      "value": 9.0,
      "name": "Games"
    },
    {
      "value": 3.0,
      "name": "Grocery"
    }
  ]
,
  "name": "Transport",
  "data": [
    {
      "value": 6.0,
      "name": "Bus"
    },
    {
      "value": 10.0,
      "name": "Train"
    }
  ]
}
If your desired result needs to be a valid json, then you could ensure it is an array. For example,
[
{ 
 name : "Online", 
 data: [....]
},
{
 name : "Transport",
 data: [...],
}
]
Then you could serialize the result you got in **Part 1** directly.
var finalResult = JsonConvert.SerializeObject(parsedData, Newtonsoft.Json.Formatting.Indented);
**Output**
[
  {
    "name": "Online",
    "data": [
      {
        "value": 9.0,
        "name": "Games"
      },
      {
        "value": 3.0,
        "name": "Grocery"
      }
    ]
  },
  {
    "name": "Transport",
    "data": [
      {
        "value": 6.0,
        "name": "Bus"
      },
      {
        "value": 10.0,
        "name": "Train"
      }
    ]
  }
]
[Demo Code][1]
	
  [1]: https://dotnetfiddle.net/4ve3ZN
