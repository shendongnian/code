    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // install filter on form activation
            Application.AddMessageFilter(this);
        }
    
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            // remove filter on form deactivation
            Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            const Int32 WM_CHAR = 0x102;
            bool ret = false;
            if (m.Msg == WM_CHAR)
            {
                char c = (char)m.WParam.ToInt32();
                if (char.IsLower(c))
                {
                    char upper = char.ToUpper(c);
                    SendMessage(m.HWnd, m.Msg, new IntPtr(upper), m.LParam);
                    ret = true;
                }
            }
            return ret;
        }
    
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    
    }
