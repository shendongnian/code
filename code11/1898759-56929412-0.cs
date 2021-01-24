"Entries": {
    "0": {
        "dateTime": "2019-07-04T00:00:00",
        "precisCode": "showers-rain",
        "min": 10,
         "max": 19
    }
}
`Entries` is an object that contains numeric key `0`, and I guess might contain `1`, `2`, etc. Under every numeric key there is a single entry object. 
To represent such a structure in C# we should use a dictionary, e.g., `Dictionary<string, Entry>` (let's rename `Entries` to `Entry`, as it should represent a single entry object). Below is the correct model:
 
c#
public class Weather
{
    // ... other properties
    // this property was declared incorrectly
    [JsonProperty(PropertyName = "Entries")]
    public Dictionary<string, Entry> Entries { get; set; }
}
// renamed from Entries
public class Entry 
{
    // ... properties
}        
### Second problem 
In the view, the model is declared as `IEnumerable<...>` while you seem to want to access a single instance of `Weather`. To list all entries from all `Weather` objects returned by the query, you should loop over the `Model` like this:
@{
    DateTime mydatetime = DateTime.Now;
    var allEntries = Model.SelectMany(m => m.Entries.Values);
}
@foreach (var entry in allEntries)
{
    <h3>
        DateTime: @mydatetime
    </h3>
    <h3>
        Forecast:@Html.DisplayFor(modelItem => entry.Forecast)
    </h3>
    <h3>
        MinTemp:  @Html.DisplayFor(modelItem => entry.MinTemp)
    </h3>
    <h3>
        MaxTemp  @Html.DisplayFor(modelItem => entry.MaxTemp)
    </h3>
}
