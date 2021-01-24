cs
var array = JArray.Parse(json);
var samples = new List<Sample>();
foreach (JProperty item in array.Last())
{
	samples.Add(new Sample()
	{
		Name = item.Name,
		Value = item.Value["value"]?.Value<int>() ?? 0
	});
}
It's also possible to do the same using `System.Text.Json` API, which is available from .NET Core 3.x
