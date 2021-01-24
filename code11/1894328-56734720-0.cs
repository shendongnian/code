	void Main()
	{
		var messageService = new MessageService();
		
		var messageReceivedObservable = Observable.FromEvent<MessageAddedToDBEventHandler, ChatMessage>(
			handler =>
			{
				MessageAddedToDBEventHandler messageAddedToDBEventHandler = (ChatMessage m) =>
				{
					handler(m);
					return m;
				};
				return messageAddedToDBEventHandler;
			},
			ev => messageService.MessageAddedToDB += ev,
			ev => messageService.MessageAddedToDB -= ev
		);
		
		messageReceivedObservable
		.Subscribe((message) =>
		{
			Console.WriteLine(message);
		});			
		
		messageService.Raise();
		messageService.Raise();
	}
	
	public delegate ChatMessage MessageAddedToDBEventHandler(ChatMessage m);
	
	public class MessageService
	{
		public event MessageAddedToDBEventHandler MessageAddedToDB;
		public void Raise()
		{
			this.MessageAddedToDB?.Invoke(new ChatMessage());
		}
	}
	
	public class ChatMessage { }
