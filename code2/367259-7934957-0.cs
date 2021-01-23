    public partial class Form1 : Form, IMessageFilter {
        public Form1() {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += delegate { Application.RemoveMessageFilter(this); };
        }
        public bool PreFilterMessage(ref Message m) {
            // Trap WM_LBUTTONDOWN
            if (m.Msg == 0x201) {
                System.Diagnostics.Debug.WriteLine("BEEP!");
            }
            return false;
        }
    }
