csharp
//Request DTO
public class RawBytes : IRequiresRequestStream
{
    /// <summary>
    /// The raw Http Request Input Stream
    /// </summary>
    Stream RequestStream { get; set; }
}
Which tells ServiceStack to skip trying to deserialize the request so you can read in the raw HTTP Request body yourself, e.g:
csharp
public object Post(RawBytes request)
{
    byte[] bytes = request.RequestStream.ReadFully();
    string text = bytes.FromUtf8Bytes(); //if text was sent
}
