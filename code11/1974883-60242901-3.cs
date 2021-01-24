public static Dictionary<int, List<HashSet<string>>> historgram = new Dictionary<int, List<HashSet<string>>>()
{
    {0, new List<HashSet<string>>()},
    {1, new List<HashSet<string>>()},
    {2, new List<HashSet<string>>()},
};
You can use the above in your code like this,
if (historgram.TryGetValue(2, out List<HashSet<string>> data)) 
if (data == null)
{
    data = new List<HashSet<string>>();
    data.Add(new HashSet<string>() { "XXXX-2244" });
}
else
{
    data.Add(new HashSet<string>() { "XXXX-2255" });
}
At this point, your original histogram is also updated. Note that data is a reference to value of your dictionary's key.
dynamic output = new ExpandoObject();
output.histogram = historgram;
Console.WriteLine(JsonConvert.SerializeObject(output, Formatting.Indented));
// Generates the following output...
{
  "histogram": {
    "0": [],
    "1": [],
    "2": [
      [
        "XXXX-2255"
      ]
    ]
  }
}
