    [MessageContract]
    public class UploadFileMessage
    {
       [MessageHeader]
       public string Filename { get; set; }
       [MessageBodyMember]
       public Stream Content { get; set; }
    }
