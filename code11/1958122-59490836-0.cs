public class Root
{
    public List<List<User>> user { get; set; } // LIST OF LIST OF USER
    public List<List<Token>> token { get; set; } // LIST OF LIST OF TOKEN
}
**REASON**  Since your json shows user to be a list of a list of users and token to be a list of list of tokens, you need to set up the object like that as well.
When I tried to deserialize this, it worked fine.
var rootObject = JsonConvert.DeserializeObject<Root>(json);
