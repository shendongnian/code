    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void FillList()
        {
            var fi = new InputForm();
            fi.Value = textBox1.Text;  // set initial value from main form
            if (fi.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fi.Value; // get input value back to main form
            }
        }
    }
