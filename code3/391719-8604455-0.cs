    public MainViewModel()
    {
        try
        {
            GetData();
        }
        catch (Exception e)
        {
            Messenger.Default.Send(new DialogMessage(this, e.Message, MessageBoxCallback) { Caption = "Error!" });
        }
    }
    private void MessageBoxCallback(MessageBoxResult result)
    {
        // Stuff that happens after dialog is closed
    }
    public class View1 : UserControl
    {
        public View1()
        {
            InitializeComponent();
            Messenger.Default.Register<DialogMessage>(this, DialogMessageReceived);
        }
        private void DialogMessageReceived(DialogMessage msg)
        {
                MessageBox.Show(msg.Content, msg.Caption, msg.Button, msg.Icon, msg.DefaultResult, msg.Options);
        }
    }
