    [MessageContract]
    public class FileUploadMessage
    {
    [MessageHeader(MustUnderstand = true)]
    public int MyInt {get;set;
    
    [MessageHeader(MustUnderstand = true)]
    public string MyString {get;set;
    
    [MessageBodyMember(Order = 1)]
    public System.IO.Stream FileByteStream {get;set;}
    }
