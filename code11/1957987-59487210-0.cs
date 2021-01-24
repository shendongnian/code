     [DataContract()]
     public class PaymentInvoiceResult
     {
    	[DataMember]
    	public int Id { get; set; }
    	
    	[DataMember]
    	public int No { get; set; }
    	
    	[DataMember]
    	public int NetAmount { get; set; }
    	
    	[DataMember]
    	public int PaidAmount { get; set; }
    	
    	[DataMember]
    	public int AmountToBePayed { get; set; }
     }
