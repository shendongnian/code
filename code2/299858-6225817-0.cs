    public partial class Server : Form
        {
            private UInt32 msg;
            public Server()
            {
                InitializeComponent();
    
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                msg = RegisterWindowMessage("THIS_IS_MY_UNIQUE_MESSAGE");
            }
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern uint RegisterWindowMessage(string lpString);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool SendNotifyMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
    
            private void SendMessage(object sender, EventArgs e)
            {
                var retval = SendNotifyMessage(new IntPtr(-1), msg, 0, 0);
            }
    
    
        }
