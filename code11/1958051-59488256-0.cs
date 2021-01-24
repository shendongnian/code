csharp
public class Root
{
    public List<User> Users { get; set; }
    public List<Token> Tokens { get; set; }
}
Then pass this class in `DeserializeObject` function to deserialize the json.
