c#
Console.WriteLine("Dictionary Test");
var productTimeSeries2 = new Dictionary<string, IList<DeviceTimeSeries>>()
{
	{ "DeviceId-888", new List<DeviceTimeSeries>() { new Program.DeviceTimeSeries() { TimeStamp = DateTime.Now, MeasuredValue = 2, DateField = "7/29/2019" } } }
		};
Console.WriteLine(JsonConvert.SerializeObject(productTimeSeries2));
And outputs
json
{"DeviceId-888":[{"TimeStamp":"2019-07-31T20:45:28.677905+00:00","MeasuredValue":2.0,"DateField":"7/29/2019"}]}
