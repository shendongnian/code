cs
public enum SortDirection
{
    Asc,
    Desc,
}
The class would look like
public class Data
{
    ...
    [JsonProperty( "sort" )]
    public Dictionary<string,SortDirection> Sort { get; set; }
    ...
}
a minimal example
cs
var json = "{\"sort\":{\"accountName\":\"asc\",\"tradeDate\":\"desc\"}}";
var obj = JsonConvert.DeserializeObject<Data>(json);
[.net fiddle example](https://dotnetfiddle.net/EznNpG)
