    namespace Blokick.Views
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class MessagePerson : ContentPage
        {
            SignalRConnectProvider signalR = new SignalRConnectProvider();
    
            public MessagePerson()
            {
                InitializeComponent();
    
                signalR.IsStopRequested = true; // 2-) And this. Make true if running the task and go inside if statement of the IsStopRequested property.
    
                if (signalR.ChatHubProxy != null)
                {
                     signalR.Disconnect();
                }
    
                LoadSignalRMessage();
            }
        }
    }
