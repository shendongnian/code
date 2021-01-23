    public partial class Client : Form
        {
            public Client()
            {
                InitializeComponent();
            }
          
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern uint RegisterWindowMessage(string lpString);
    
          
            private static UInt32 GetMessage()
            {
                return RegisterWindowMessage("THIS_IS_MY_UNIQUE_MESSAGE");
            }
    
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == (int)GetMessage())
                {
                    MessageBox.Show(@"Hello, from server");
                }
                base.WndProc(ref m);
            }
        }
