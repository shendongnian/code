public class Types
{
    [JsonProperty("types")]
    public List<List<Type>> Values { get; set; }
}
Also, you are using the JsonProperty on the class, which is not where that normally goes. You want to use that on the property of the class.
**NOTE**: This is not a valid JSON you are working with. Json structure looks like `<key: value>` but you have is a `{ key: [][] }` which is not valid.
