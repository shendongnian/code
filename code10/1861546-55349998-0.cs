csharp
public class AuthJsonResponses
{
    public int Code { get; set; }
    public string Jwt { get; set; }
    public List<RootObject> Messages { get; private set; } = new List<RootObject>();
}
public class RootObject
{
    public string msg { get; set; }
    public string code { get; set; }
}
In your code, directly add the object to the `Message` property.  I suggest renaming it to `Messages` to indicate it's a collection
csharp
jsonRes.Messages.Add(new RootObject{msg ="Access granted", code="success_04"});
