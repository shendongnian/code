 csharp
using System;
using System.ComponentModel;
using Newtonsoft.Json;
					
public class Program
{
	public static void Main()
	{
		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
		{
			DefaultValueHandling = DefaultValueHandling.Populate
		};
		Console.WriteLine(JsonConvert.DeserializeObject<ImmutablePropertyStore>("{}"));
        Console.WriteLine(JsonConvert.DeserializeObject<ImmutablePropertyStore>(@"{propertyB: ""true""}"));    
        Console.WriteLine(JsonConvert.DeserializeObject<ImmutablePropertyStore>(@"{PropertyA: ""false"", PropertyB: ""true""}"));    
	}
}
public class ImmutablePropertyStore
{
	[DefaultValue(true)]
	public bool PropertyA { get; }
	[DefaultValue(false)]
	public bool PropertyB { get; }
	
	public ImmutablePropertyStore(bool propertyA, bool propertyB)
    {
        PropertyA = propertyA;
        PropertyB = propertyB;
    }
	
	public override string ToString()
	{
		return $"Property A is '{PropertyA}' and Property B is '{PropertyB}'.";
	}
		
}
Output:
 text
Property A is 'True' and Property B is 'False'.
Property A is 'True' and Property B is 'True'.
Property A is 'False' and Property B is 'True'.
