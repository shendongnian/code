csharp
public class Message
{
  [Key]
  public int MessageId { get; set; }
  // Some properties ...
  public virtual MessageContent MessageContent { get; set; }
}
public class MessageContent
{
  [Key]
  public int MessageContentId { get; set; }
  public virtual Message Message { get; set; }
  
  [Required, Column(TypeName = "text")]
  public string XMLString { get; set; }
  [Required]
  public MessageType Type { get; set; }
}
public enum MessageType
{
  Correction,
  Normal,
  // more options ...
}
In the model I only open the first element of a received XML which is always of type `Message`. Then I look for the child element and get its type which is `MessageType`. The `XMLString` property contains this child in `string` representation.
I know this is a bad designed solution but it works for my application just fine. I use the XSD (classes) that was provided to my on my front-end so I only have to parse the XMLString to the XSD classes.
Any better solutions are always welcome.
