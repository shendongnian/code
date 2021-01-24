`
var token = JToken.Parse(input);
var roles= token.Value<JArray>("roles");
var count = roles.Count;
`
Or you can also use JsonPath:
`
var token = JToken.Parse(input);
var count = token.SelectTokens("$.roles[*]").Count();
`
But ideally, you should be serilizing into an object and then using the properties to get the Count:
`
public class Role
{
    public int id { get; set; }
    public string name { get; set; }
    public int rank { get; set; }
    public int memberCount { get; set; }
}
public class MyObject
{
    public int Someid { get; set; }
    public List<Role> roles { get; set; }
}
var item = JsonConvert.DeserializeObject<MyObject>(input);
var count = item.roles.Count;
