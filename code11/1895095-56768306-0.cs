    // ignore a property on a condtion
    public bool ShouldSerializeCities() => Cities != null && Cities.Count > 0;
**Update 1:**
As @DavidG mentioned the workaround above won't ignore string fields (Name and Code) if they are null or empty. For making that happen you need to make use of `DefaultValue`:
Define `JsonConvert` settings like this:
		var settings = new JsonSerializerSettings {
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
Use `DefaultValue` attribute over your desiarred field/properties:
public class City
{
	[DefaultValue("")]
	public string Name
	{
		get;
		set;
	}
	[DefaultValue("")]
	public string Code
	{
		get;
		set;
	}
}
Serialize your object with the settings you created above:
    JsonConvert.SerializeObject(obj, settings) ;
For example, if your object looks like this:
		var obj = new Foo{
			Cities = new  [] {
				new City() {Name = "A", Code = ""}
				, new City() {Name = "B", Code = "C"}
				, new City(){Name = "", Code = ""}
			}
		};
The result will be:
{
  "Cities": [
    {
      "Name": "A"
    },
    {
      "Name": "B",
      "Code": "C"
    },
    {}
  ]
}
[I created a project on .NET Fiddle to see how it works.][2]
If you don't like creating new settings, you still can use `ShuldSerializeMemberName` inside your `City` class:
public class City
{
   public string Name{get;set;}
   public bool ShouldSerializeName() => !string.IsNullOrEmpty(Name);
}
  [1]: https://www.newtonsoft.com/json/help/html/ConditionalProperties.htm
  [2]: https://dotnetfiddle.net/MzoITo
