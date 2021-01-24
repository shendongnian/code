public class User : AJsonSerializer<User>
{
    public string PublicKey { get; set; }
    public int User_ID { get; set; }
}
public abstract class AJsonSerializer<T>
    where T : class
{
    public string ToJson() {
        return JsonConvert.SerializeObject(this);
    }
    public static T FromJson(string jsonString) {
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
Edit: and as Kara stated in her comment, your `FromJson` method can be static. So you can call it like
var user = User.FromJson(jsonString);
