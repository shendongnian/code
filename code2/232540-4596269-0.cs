    [MessageContract]
    public class FileDownloadMessage
    {
        [MessageBodyMember( Order = 1 )]
        public System.IO.MemoryStream FileByteStream;
    }
