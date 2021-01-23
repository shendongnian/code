    [MessageContract]
    public class FileUploadInputParameter
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName { get; set; }
    
        [MessageHeader(MustUnderstand = true)]
        public decimal FileSize { get; set; }
    
        [MessageBodyMember(Order = 1)]
        public Stream FileStream { get; set; }
    }
    
    [MessageContract]
    public class FileDataContract : FileUploadInputParameter
    {        
        [MessageHeader(MustUnderstand=true)]
        public int ExternalCustomerId { get; set; }
    
        [MessageHeader(MustUnderstand=true)]
        public string DomainName{get;set;}
    
        [MessageHeader(MustUnderstand=true)]
        public bool IsDefault{get;set;}
    }
