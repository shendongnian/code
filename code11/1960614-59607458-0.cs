    [DataContract]
    public partial class Fieldname
    {
    [DataMember(EmitDefaultValue = false)]
    [JsonProperty("display_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }
    [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }
    [JsonProperty("default", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Default { get; set; }
    //[JsonProperty("list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    //public List List { get; set; }
    }
