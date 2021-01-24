CSharp
var value = new StreamObject { Comma = ',' };
value.Stream = new MemoryStream(Encoding.ASCII.GetBytes("turn left then right and go straight"));
var str = System.Text.Json.JsonSerializer.Serialize(value);
raises error like `Timeouts are not supported on this stream.` when trying to serialise the MemoryStream.
Please consider using the `byte[]` or `string` data type but not `Stream`.
You can use it with `string` according to the Postman sample you had shown:
[DataContract]
public class StreamObject
{
    [DataMember]
    public Char Comma { get; set; }
    [DataMember]
    public string Stream { get; set; }
}
