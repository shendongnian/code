    public class Loan 
    {
        public long Id { get; set; }
        public virtual User User{ get; set; }
        public virtual List<Document> Documents{ get; set; }
        public LoanStatus LoanStatus{ get; set; }
             
    }
    public enum LoanStatus
    {       
       UserValidated,
       DocumentUploaded,
       DocumentVerified,
       DocumentApproved,
       LoanEligibility...
    }
