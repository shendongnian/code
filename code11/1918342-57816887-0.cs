public class Message
{
    public string MessageBody { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
}
string json = @"{
  'MessageBody': 'This is a test Message.',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
}";
And in your class which has the functions you can simply do:
Message msg = JsonConvert.DeserializeObject<Message>(json);
And now you can use it like:
Console.WriteLine(msg.MessageBody);
**Second Way**
For .NET CORE Projects, there is another way to do it,
