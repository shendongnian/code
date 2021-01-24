	public class CredoPayRequest
	{
		// properties shared between all requests
		// ...
		public string depositId { get; set; }
		public string utilityId { get; set; }
		public string loanId { get; set; }
	}
	
	var request = new CredoPayRequest
	{
		// assign shared properties
		// ...
		utilityId = "Foo"
	};
