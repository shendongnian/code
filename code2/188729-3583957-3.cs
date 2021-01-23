    [ServiceContract]     
    public interface IFileTransferService     
    {     
        [OperationContract]     
        DownloadFileResponse DownloadFile(DownloadFileRequest request);     
    }     
    [MessageContract]     
    public class DownloadFileRequest     
    {     
        [MessageBodyMember]     
        public string FileName;     
    }     
     
    [MessageContract]     
    public class DownloadFileResponse    
    {     
        [MessageHeader]     
        public string FileName;     
     
        [MessageHeader]     
        public long Length;     
     
        [MessageBodyMember]     
        public System.IO.Stream FileByteStream;         
    } 
