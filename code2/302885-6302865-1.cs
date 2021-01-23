	public class ChatEventArgs : EventArgs
	{
		public string ChatEventArgs(string message)
		{
			Message = message;
		}
		
		public string Message { get; private set; }
	}
	public interface IChatMessageProvider
	{
		event EventHandler<ChatEventArgs> MessageArrived;
		void TriggerEvent(object source, ChatEventArgs args);
	}
	public class MainWindow : IChatMessageProvider
	{
		public event EventHandler<ChatEventArgs> MessageArrived = delegate{};
		
		public void AddChatWindow()
		{
			ChatWindow window = new ChatWindow(this);
			window.Show();
		}
		
		public void TriggerEvent(object source, ChatEventArgs args)
		{
			MessageArrived(source, args);
		}
	}
	public class ChatWindow : 
	{
		IChatMessageProvider _provider;
		
		public ChatWindow(IChatMessageProvider provider)
		{
			_provider = provider;
			provider.MessageArrived += OnMessage;
		}
		
		
		public void OnMesage(object source, ChatEventArgs args)
		{
			// since we could have sent the message
			if (source == this)
				return;
				
			myListBox.Items.Add(args.Message);
		}
		
		public void SendButton_Click(object source, EventArgs e)
		{
			_provider.TriggerEvent(this, new ChatEventArgs(Textbox1.Text));
		}
	}
