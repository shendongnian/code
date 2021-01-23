	public class BusinessLogic
	{
		public event DisplayMessage DisplayMessage;
		public event DisplayDialogBox DisplayDialogBox;
		
		protected void OnDisplayMessage(string message)
		{
			var dm = this.DisplayMessage;
			if (dm != null)
			{
				dm(message);
			}
		}
		
		protected bool OnDisplayDialogBox(string message, string caption)
		{
			var ddb = this.DisplayDialogBox;
			if (ddb != null)
			{
				return ddb(message, caption);
			}
			return false;
		}
		
		public void SomeMethod()
		{
			this.OnDisplayMessage("Hello, World!");
			var result = this.OnDisplayDialogBox("Yes or No?", "Choose");
			this.OnDisplayMessage(result.ToString());
		}
	}
