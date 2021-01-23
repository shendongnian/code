    [Serializable]
    public class ParseTaskMessage : BaseMessage
    {
        public Guid TaskId { get; set; }
    
        public string BlobReferenceString { get; set; }
    
        public DateTime TimeRequested { get; set; }
    }
