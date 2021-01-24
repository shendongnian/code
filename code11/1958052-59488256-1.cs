csharp
public class Root
{
    public List<List<User>> Users { get; set; }
    public List<List<Token>> Tokens { get; set; }
}
Then pass this class in `DeserializeObject` function to deserialize the json.
