public class themessage
{
    public string to;
}
public class body
{
    public string type;
    public string contentType;
    public string from;
    public string subject;
    public string content;
    public themessage[] messages; // <- Array here
}
and the object you create with it will be something like
var obj = new body
{
    type = "SMS",
    contentType = "COMM",
    from = "PN",
    subject = "subject",
    content = "Hell World",
    messages = new themessage[] { new themessage{to = "PN"} }
};
The code for the `RestClient` and `RestRquest` stays as it is.
