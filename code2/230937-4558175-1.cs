    public interface ISuppressEsc
    {
        // marker interface, no declarations
    }
    public partial class UserControl1 : UserControl, ISuppressEsc
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Text = DateTime.Now.ToLongTimeString();
            }
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            var activeCtl = ActiveControl;
            if (!(activeCtl is ISuppressEsc) && e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
