    MessengerClass _communicator;
    public Form1()
    {
        InitializeComponent();
        _communicator = new MessengerClass();
        _communicator.OnIMWindowCreated += new DMessengerEvents_OnIMWindowCreatedEventHandler(_communicator_OnIMWindowCreated);
        _communicator.OnIMWindowDestroyed += new DMessengerEvents_OnIMWindowDestroyedEventHandler(_communicator_OnIMWindowDestroyed);
        _communicator.OnIMWindowContactAdded += new DMessengerEvents_OnIMWindowContactAddedEventHandler(_communicator_OnIMWindowContactAdded);
        _communicator.OnIMWindowContactRemoved += new DMessengerEvents_OnIMWindowContactRemovedEventHandler(_communicator_OnIMWindowContactRemoved);
        _communicator.OnMyStatusChange += new DMessengerEvents_OnMyStatusChangeEventHandler(_communicator_OnMyStatusChange);
    }
    void _communicator_OnMyStatusChange(int hr, MISTATUS mMyStatus)
    {
        AddText(string.Format("My Status changed to '{0}'", mMyStatus));
    }
    void _communicator_OnIMWindowContactRemoved(object pContact, object pIMWindow)
    {
        AddText(string.Format("{0}   - Participant removed - '{1}'", ((IMessengerConversationWndAdvanced)pIMWindow).HWND, ((IMessengerContactAdvanced)pContact).SigninName));
    }
    void _communicator_OnIMWindowContactAdded(object pContact, object pIMWindow)
    {
        AddText(string.Format("{0}   - Participant added - '{1}'", ((IMessengerConversationWndAdvanced)pIMWindow).HWND, ((IMessengerContactAdvanced)pContact).SigninName));
    }
    void _communicator_OnIMWindowDestroyed(object pIMWindow)
    {
        AddText(string.Format("{0} Conversation Closed, duration = {1}", ((IMessengerConversationWndAdvanced)pIMWindow).HWND, (DateTime.Now - _start).ToString()));
    }
    void _communicator_OnIMWindowCreated(object pIMWindow)
    {
        try
        {
            AddText(string.Format("{0} Conversation Created", ((IMessengerConversationWndAdvanced)pIMWindow).HWND));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    private delegate void AddTextDelegate(string text);
    private void AddText(string text)
    {
        if (textBox1.InvokeRequired)
        {
            textBox1.Invoke(new AddTextDelegate(AddText), text);
            return;
        }
        textBox1.Text += text + "\r\n";
    }
