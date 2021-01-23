    public partial class MainForm : Form
    {
        private class MessageFilter : IMessageFilter
        {
            public MainForm Main { get; set; }
            public bool PreFilterMessage(ref Message msg)
            {
                const int WM_KEYDOWN = 0x100;
                const int WM_KEYUP = 0x101;
                if (msg.Msg == WM_KEYDOWN)
                {
                    var keyData = (Keys)msg.WParam;
                    if (keyData == Keys.Down || keyData == Keys.Up)
                    {
                        return true; // Process keys before return
                    }
                }
                else if (msg.Msg == WM_KEYUP)
                {
                    var keyData = (Keys)msg.WParam;
                    if (keyData == Keys.Down || keyData == Keys.Up)
                    {
                        return true; // Process keys before return
                    }
                }
                return false;
            }
        }
        public MainForm()
        {
            this.InitializeComponent();
            Application.AddMessageFilter(new MessageFilter { Main = this });
        }
    }
