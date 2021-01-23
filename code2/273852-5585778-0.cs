    public class Order
    {
        public int Id { get; set; }
    
        public virtual Patient Patient { get; set; }
    
        public virtual CertificationPeriod CertificationPeriod { get; set; }
    
        public virtual Agency Agency { get; set; }
    
        public virtual Diagnosis PrimaryDiagnosis { get; set; }
    
        public virtual OrderApprovalStatus ApprovalStatus { get; set; }
    
        public virtual User Approver { get; set; }
    
        public virtual User Submitter { get; set; }
    
        public DateTime ApprovalDate { get; set; }
    
        public DateTime SubmittedDate { get; set; }
        public Boolean IsDeprecated { get; set; }
    }
