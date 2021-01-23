    public partial class Window1 : Window
    {
        private XmppClientConnection _client;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(XmppClientConnection client):this()
        {
            _client = client;
        }
    }
