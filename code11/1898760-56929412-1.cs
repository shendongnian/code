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
BTW, this code in your controller:
c#
items.Select(t => new Entries { 
    Datetime = t.Datetime,
    Forecast = t.entries.Forecast,
    MinTemp = t.entries.MinTemp,
    MaxTemp = t.entries.MaxTemp
}).ToList();
is completely redundant and has no effect.
### If you want to display only a single Weather object
Then in the view, change the model to be of type `Weather`, and change the loop accordingly, as shown below:
@model PelicanboatRamp.Models.Weather
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
@{
    DateTime mydatetime = DateTime.Now;
}
@foreach (var entry in Model.Entries.Values)
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
In the controller, pick a single `Weather` object to pass to the view:
c#
[ActionName("Index")]
public async Task<ActionResult> IndexAsync()
{
    DateTime thisDay = DateTime.Today;
    var items = await DocumentDBRepository<Weather>.GetWeatherAsync(d => d.Id != null);
    // select a single Weather object according to your business logic
    // for example like this:
    var todaysWeather = items.Single(weather => weather.DateTime.Date == thisDay);
    // pass the single Weather to the view
    return View(todaysWeather);
}
