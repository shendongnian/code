    public class MainViewModel
    {
    	public RelayCommand myCommand { get; private set; }
    	public MainViewModel()
    	{
    		myCommand = new RelayCommand( () => SendTheMessage());
    	}
    	public void SendTheMessage()
    	{
    		Messenger.Default.Send("I have sent the message");
    	}
    }
