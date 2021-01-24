    //Request DTO
    public class RawBytes : IRequiresRequestStream
    {
        /// <summary>
        /// The raw Http Request Input Stream
        /// </summary>
        Stream RequestStream { get; set; }
    }
    
    
    public object Post(RawBytes request)
    {
        byte[] bytes = request.RequestStream.ReadFully();
        string text = bytes.FromUtf8Bytes(); //if text was sent
    }
