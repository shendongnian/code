 c#
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
static class Program
{
    static void Main()
    {
        var request = @"{""filter"": {""filters"": [{""field"": ""SCT_CATEGORY"", ""value"": 10000, ""operator"": ""eq""}]}}";
        var obj = JsonConvert.DeserializeObject<Request>(request);
        var filter = obj.Filter.Filters.Single();
        Console.WriteLine(filter.Operator); // "eq"
        Console.WriteLine(filter.Logic); // null
        Console.WriteLine(filter.Value); // 10000
        Console.WriteLine(filter.Value2); // null
        Console.WriteLine(filter.Field); // SET_CATEGORY
    }
}
public class Request // just to shape the json
{
    public RequestFilters Filter { get; set; }
}
public class RequestFilters // just to shape the json
{
    public List<GridFilter> Filters { get; } = new List<GridFilter>();
}
public class GridFilter
{
    public string Operator { get; set; }
    public string Field { get; set; }
    public object Value { get; set; }
    public object Value2 { get; set; }
    public string Logic { get; set; }
}
If you also want to be able to *serialize* retaining the case, you'd need to tell the serializer:
 c#
public class Request // just to shape the json
{
    [JsonProperty("filter")]
    public RequestFilters Filter { get; set; }
}
public class RequestFilters // just to shape the json
{
    [JsonProperty("filters")]
    public List<GridFilter> Filters { get; } = new List<GridFilter>();
}
public class GridFilter
{
    [JsonProperty("operator")]
    public string Operator { get; set; }
    [JsonProperty("field")]
    public string Field { get; set; }
    [JsonProperty("value")]
    public object Value { get; set; }
    [JsonProperty("value2")]
    public object Value2 { get; set; }
    [JsonProperty("logic")]
    public string Logic { get; set; }
}
