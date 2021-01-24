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
public Class Coins
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
public Class Coins
{
    public int Total { get; set;}
}
