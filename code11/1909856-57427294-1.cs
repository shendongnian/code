    jsonSerializer.JsonDeserialize<Wrapper>(rawMessage);
     internal class Wrapper
    {
        public string LocalReferenceNumber { get; set; }
        public string DeclarationStatus { get; set; }
        public string SubmittingBy { get; set; }
        public DateTime SubmittedOn { get; set; }
    }
  
