c#
public class PersistablePerson
{
    public string name {get; set;}
    public int department {get; set;}
    
    [JsonIgnore] // exclude from JSON serialization, include in persistence
    public string addresses {get; set;}
    [IgnoreProperty]            // exclude from persistence
    [JsonProperty("addresses")] // include in JSON serilization
    public JToken addressesJson
    {
        get { return addresses != null ? JToken.Parse(addresses) : null; }
        set { addresses = value.ToString(); }
    }
    [JsonIgnore] // exclude from JSON serialization, include in persistence
    public string skill {get; set;}
    [IgnoreProperty]        // exclude from persistence
    [JsonProperty("skill")] // include in JSON serilization
    public JToken skillJson
    {
        get { return skill != null ? JToken.Parse(skill) : null; }
        set { skill = value.ToString(); }
    }
}
