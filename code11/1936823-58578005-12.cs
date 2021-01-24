    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public void HandleKeys(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                textBox1.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F11)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }
    }
