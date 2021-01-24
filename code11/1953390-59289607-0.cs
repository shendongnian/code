class Input {
  [JsonConverter(typeof(......))]
  public InputType Type {get; set;}
  [JsonExtensionData]
  public IDictionary<string, object> Properties {get; set;}
}
