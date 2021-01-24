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
