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
    public T FromJson(string jsonString) {
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
