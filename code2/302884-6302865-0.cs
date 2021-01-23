	public class ChatEventArgs : EventArgs
	{
		public string ChatEventArgs(string message)
		{
                     Message=message;
		}
                public string Message {get;private set;}
	}
	public interface IChatMessageProvider
	{
		event EventHandler<ChatEventArgs> MessageArrived;
	}
	public class MainWindow : Form, IChatMessageProvider
	{
		public event EventHandler<ChatEventArgs> MessageArrived = delegate{};
		
		public void AddChatWindow()
		{
			ChatWindow window = new ChatWindow(this);
			window.Show();
		}
	}
	public class ChatWindow : Form
	{
		public ChatWindow(IChatMessageProvider provider)
		{
			provider.MessageArrived += OnMessage;
		}
		
		
		public void OnMesage(object source, ChatEventArgs args)
		{
			// since we could have sent the message
			if (source == this)
				return;
				
			myListBox.Items.Add(args.Message);
		}
	}
