c#
using Newtonsoft.Json;
...
internal static class MyConverter
{
	internal static T Convert<T>(object source)
	{
		string json = JsonConvert.SerializeObject(source);
		T result = JsonConvert.DeserializeObject<T>(json);
		return result;
	}
}
usage:
c#
var s1 = new PerSecStruct { YQ = "1", EPS = 2, NAV = 3, Cash = 4, Debt = 5 };
// to object
var o = MyConverter.Convert<PerSec>(s1);
// back to struct
var s2 = MyConverter.Convert<PerSecStruct>(o);
 
  [1]: https://www.newtonsoft.com/json
