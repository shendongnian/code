    [MessageContract]
    public class DownloadFileRequest
    {
      [MessageHeader(MustUnderstand = true)]
      public Guid FileId { get; set; }
    }
