    [MessageContract]
    public class DownloadFileResponse : IDisposable
    {
      [MessageHeader(MustUnderstand = true)]
      public Guid FileId { get; set; }
    
      [MessageHeader(MustUnderstand = true)]
      public Int32 FileSize { get; set; }
    
      [MessageHeader(MustUnderstand = true)]
      public String FileName { get; set; }
    
      [MessageBodyMember(Order = 1)]
      public Stream FileByteStream { get; set; }
    
      public void Dispose()
      {
        if (FileByteStream != null)
          FileByteStream.Dispose();
      }
    }
