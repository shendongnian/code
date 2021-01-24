json
{
    "coins": {
        "Total": 1004
    }
}
And
json
{
    "c": {
        "Total": 1004
    }
}
And a models like this:
csharp
public class CoinsWrapper
{
    [JsonProperty("c")]
    public Coins coins { get; set;}
}
public class Coins
{
    public int Total { get; set;}
}
**Solution 1 - Create Secondary Propety**
csharp
public class CoinsWrapper
{
    [JsonProperty("c")]
    public Coins coins { get; set;}
    [JsonProperty("coins")]
    private Coins legacyCoins { set { coins = value; } }
}
And then when you deserialize it will assign the value to coins, and when you serialize it will ignore legacyCoins.
----------
**Solution 2 - use `JsonExtensionData` and reflection to 'map' automatically**
I decided to have a bit of fun with this... obviously you'll need to be careful with this because if your naming has any overlap you could cause things to blow up pretty easily. I would suggest maybe taking a bit further and creating a new custom attribute for safety, but this works in LINQpad for this example just fine.
csharp
void Main()
{
	string json = @"{
	    ""coins"": {
	        ""Total"": 1004
	    }
	}";
	var wrapper = JsonConvert.DeserializeObject<CoinsWrapper>(json);
	wrapper.Dump();
}
public class CoinsWrapper : LegacyAutoMap
{
	[JsonProperty("c")]
	public Coins coins { get; set; }
}
public abstract class LegacyAutoMap
{
	[JsonExtensionData]
	private IDictionary<string, JToken> _additionalData;
	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		if (_additionalData == null) return;
		var properties = this.GetType().GetProperties();
		foreach (var entry in _additionalData)
		{
			var prop = properties.FirstOrDefault(p => p.Name.ToLowerInvariant() == entry.Key.ToLowerInvariant());
			if (prop == null) continue;
			JToken token = entry.Value;
			MethodInfo ifn = typeof(JToken).GetMethod("ToObject", new Type[0]).MakeGenericMethod(new[] { prop.PropertyType });
			prop.SetValue(this, ifn.Invoke(token, null));
		}
		_additionalData = null;
	}
}
----------
**Solution 3 - Introduce a new custom attribute combined with solution 2**
This is the most flexible and probably safest solution. Flexible because you can provide multiple alternate names, and safest because only those fields you specify will be 'auto mapped'.
csharp
void Main()
{
	string json = @"[{
	    ""coins"": {
	        ""Total"": 1004
	    }
	},{
		    ""c"": {
	        ""Total"": 1004
	    }
	},{
		    ""coinz"": {
	        ""Total"": 1004
	    }
	}]";
	var wrapper = JsonConvert.DeserializeObject<CoinsWrapper[]>(json);
	wrapper.Dump();
}
public class CoinsWrapper : LegacyAutoMap
{
	[JsonProperty("c")]
	[AlternateJSONName("coins")]
	[AlternateJSONName("coinz")]
	public Coins coins { get; set; }
}
public class Coins
{
	public int Total { get; set; }
}
public abstract class LegacyAutoMap
{
	[JsonExtensionData]
	private IDictionary<string, JToken> _additionalData;
	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		if (_additionalData == null) return;
		
		var mappableProps = this.GetType()
			.GetProperties()
			.Where(p => Attribute.IsDefined(p, typeof(AlternateJSONNameAttribute)))
			.Select(p =>
			{
				var attrs = p.GetCustomAttributes(typeof(AlternateJSONNameAttribute)).Cast<AlternateJSONNameAttribute>();
				return attrs.Select(attr => new { AlternateName = attr.JSONKey.ToLowerInvariant(), Property = p });
			})
			.SelectMany(attrs => attrs);
		
		foreach (var entry in _additionalData)
		{
			var prop = mappableProps.FirstOrDefault(p => p.AlternateName == entry.Key.ToLowerInvariant());
			if (prop == null) continue;
			JToken token = entry.Value;
			MethodInfo ifn = typeof(JToken).GetMethod("ToObject", new Type[0]).MakeGenericMethod(new[] { prop.Property.PropertyType });
			prop.Property.SetValue(this, ifn.Invoke(token, null));
		}
		_additionalData = null;
	}
}
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class AlternateJSONNameAttribute : Attribute
{
	public string JSONKey { get; }
	public AlternateJSONNameAttribute(string keyName)
	{
		this.JSONKey = keyName;
	}
}
