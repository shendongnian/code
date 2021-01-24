    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            // KeyPreview can be set in the properties of the child form instead
            child.KeyPreview = true;
            child.KeyPressed += Child_KeyPressed;
            child.ShowDialog();
        }
        private void Child_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                // Save Pressed
            }
        }
    }
