lang-cs
public string Post([FromBody]PostObject postObj)
{
    return $"Hello, {postObj.Name}!";
}
public class PostObject 
{
    [JsonProperty("name")]
    public string Name { get; set; }
}
In that way you could send a lot more then only a string and your Postman call wouldn't change.
