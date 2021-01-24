	public class Printer
	{
		private MessageOrigin mo;
		
		public Printer() 
		{
			mo = new MessageOrigin(this);
		}
		
		public void printMessage(string message) 
		{
			Console.WriteLine(message); // message here should come from the MessageOrigin class
		}
	}
	
	public class MessageOrigin
	{
        private Printer _parentPrinter;
		public MessageOrigin(Printer print) 
		{
            _parentPrinter = print;
		}
		public string Get_All_Message() 
		{
			//implementation
			return string.Empty;
		}
		public void GetMessage() {
			var msgs = Get_All_Message();
			SendMessageToPrintClass(msgs);
		}
		public void SendMessageToPrintClass(string message) {
			// how do I send the "message" parameter back to the Printer class
           _parentPrinter.Message = message //note that you need to implement your message method/property.
		}
	}
