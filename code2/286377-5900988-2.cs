    public partial class UserControl1 : UserControl, IMessageFilter
    {
        public UserControl1() {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
    
        public bool PreFilterMessage(ref Message m) {
            if (!this.IsDisposed && this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition))) {
                this.BackColor = Color.Green; // Or whatever border color you want.
            } else {
                this.BackColor = SystemColors.Control;  // Back to the UC's default border color.
            }
            return false;
       }
    }
