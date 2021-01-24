seri_obj = JsonConvert.DeserializeObject<object[]>(FormattedJson);
You are asking the deserializer to return an array raw objects, which will result in an array of `JObject` types, not your `FlagClass` and `CurrentAmplitude` types.
You're also setting `seri_obj`, but never assigning the values in `seri_obj` to your `obj` or `obj2` variables, which is why the compiler is warning you.
You would be better off having an umbrella configuration class like this:-
class Configuration
{
    public Flag { get; set; } = new FlagClass();
    public CurrentAmplitude { get; set; } = new CurrentAmplitude();
}
Then just deserialize/serialize an instance of your `Configuration` class when you want to load/save...
// create config object if new
var config = new Configuration();
// to save
var json = JsonConvert.SerializeObject(config);
// to load
var config = JsonConvert.DeserializeObject<Configuration>(json);
// get/set config values
config.Flag.flag2 = false;
Here is a more complete example:-
void Main()
{
	// create a new blank configuration
	Configuration config = new Configuration();
	
	// make changes to the configuration
	config.CurrentAmplitude.value1 = 123;
	config.CurrentAmplitude.value2 = "Hello";
	config.FlagClass.flag1 = false;
	config.FlagClass.flag2 = true;
	
	// serialize configuration to a string in order to save to a file
	string json = JsonConvert.SerializeObject(config);
	
	// reload config from saved string
	config = JsonConvert.DeserializeObject<Configuration>(json);
	
	// should print "Hello"
	Console.WriteLine(config.CurrentAmplitude.value2);
}
class Configuration
{
	public CurrentAmplitude CurrentAmplitude { get; set; } = new CurrentAmplitude();
	
	public FlagClass FlagClass { get; set; } = new FlagClass();
}
class CurrentAmplitude
{
	public int value1 { get; set; }
	public string value2 { get; set; }
	public string value3 { get; set; }
	public string value4 { get; set; }
	public string value5 { get; set; }
}
class FlagClass
{
	public bool flag1 { get; set; }
	public bool flag2 { get; set; }
}
