    public partial class ChildForm : Form
    {
        public event EventHandler<KeyEventArgs> KeyPressed;
        public ChildForm()
        {
            InitializeComponent();
        }
        private void Child1_KeyUp(object sender, KeyEventArgs e)
        {
            KeyPressed?.Invoke(sender, e);
        }
    }
