    public class Payment
    {
    	public decimal Amount { get; set; }
    	[XmlElement("Loan")] 
    	public List<Loan> Loans { get; set; }
    }
    public class Loan
    {
    	public decimal Debt { get; set; }
    	public string Lender { get; set; }
    }
