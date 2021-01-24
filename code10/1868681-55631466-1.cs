	public abstract class CredoPayRequest
	{
		// ...
	}
	
	public class DepositRequest : CredoPayRequest
	{	
		public string depositId { get; set; }
	}
	
	var request = new DepositRequest
	{
		// ...
		depositId = "Foo"
	};
