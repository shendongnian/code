    public class Submission
    {
        public Submission()
        {
            this.Customer = new Customer();
        }
    
        public int SubmissionId { get; set; }
        public int Status { get; set; }
        public string StatusComment { get; set; }
        public Customer Customer { get; set; }
    }
    public class Customer
    {
        //public Customer() { }
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustState { get; set; }
        public string CustCity { get; set; }
        public int CustZip { get; set; }
        public int SicNaic { get; set; }
    }
