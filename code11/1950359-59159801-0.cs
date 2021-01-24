public  class MyData
{
    [JsonProperty("AAA BBBB (AA/BBB) A")]
    public List<MyObject> AAABBBBAABBBA{ get; set; }
    [JsonProperty("AAA BBBB (AA/BBB) B")]
    public List<MyObject> AAABBBBAABBBB{ get; set; }
}
by default, newtonsoft.json does not deserialize correctly if the name of the variable doesnt exactly match.
I think you can use a single object for both of the lists
public  class MyObject
{
    public  string commodity { get; set; }
    public  string direction { get; set; }
...
}
