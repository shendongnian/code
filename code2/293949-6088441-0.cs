    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            if (pnl != null)
            {
                pnl.BackColor = Color.Red;
            }
        }
    }
