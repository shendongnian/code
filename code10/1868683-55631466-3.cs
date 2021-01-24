	public abstract class CredoPayRequest
	{
		// properties shared between all requests
	}
	
	public class DepositRequest : CredoPayRequest
	{	
		public string depositId { get; set; }
	}
	
	public class UtilityRequest : CredoPayRequest
	{	
		public string utilityId { get; set; }
	}
	
	public class LoanRequest : CredoPayRequest
	{	
		public string loanId { get; set; }
	}
	
	var request = new DepositRequest
	{
		// assign shared properties
		// ...
		depositId = "Foo"
	};
