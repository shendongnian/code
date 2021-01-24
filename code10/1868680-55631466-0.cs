	public class CredoPayRequest
	{
		// ...
		public string depositId { get; set; }
		public string utilityId { get; set; }
		public string loanId { get; set; }
	}
	
	var request = new CredoPayRequest
	{
		// ...
		utilityId = "Foo"
	};
