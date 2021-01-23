    public partial class Form1 : 
        Form,
        IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            //here you can specify  which key you need to filter
            if (m.Msg == 0x0100 && (Keys)m.WParam.ToInt32() == Keys.S &&
                ModifierKeys == Keys.Control) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
