	MessageViewModel
	{
		public MessageViewModel()
		{
		}
		Guid ID { get; set; } 
		DateTime TimeCreated { get; set; } 
		String Content {get; set;}
	} 
	static MessageFactory
	{
		public static Message Build(MessageViewModel viewModel)
		{
			var result = new Message(viewModel.ID, viewModel.TimeCreated);
			result.Content .... 
			etc etc
			
			return result;
		}
	} 
        JavaScriptSerializer jss = new JavaScriptSerializer();
        MessageViewModel viewModel = jss.Deserialize<MessageViewModel>(jsonString);
        var message = MessageFactory.Build(viewModel);
