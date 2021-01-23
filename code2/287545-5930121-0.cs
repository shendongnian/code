	public class SomeDataModel
	{
		public string Content { get; set; }
		public ICommand Command { get; set; }
		public SomeDataModel(string content, ICommand command)
		{
			Content = content;
			Command = command;
		}
	}
