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
And you need to be able to deserialize it into the wrapper.
Can you not just do this? JSON.net supports a model like this:
csharp
public class CoinsWrapper
{
    [JsonProperty("c")]
    public Coins coins { get; set;}
    [JsonProperty("coins")]
    private Coins legacyCoins { set { coins = value; } }
}
public class Coins
{
    public int Total { get; set;}
}
And then when you deserialize it will assign the value to coins, and when you serialize it will ignore legacyCoins.
----------
**Edit to use `JsonExtensionData` and reflection to automap**
This is a solution that might work - it is certainly an interesting approach I decided to have a bit of fun with... obviously you'll need to be careful with this because if your naming has any overlap you could cause things to blow up pretty easily.
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
public class Coins
{
	public int Total { get; set; }
}
