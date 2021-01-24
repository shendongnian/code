    public partial class MainForm : Form
    {
        InputForm fi = new InputForm() { Value = "Default" };
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fi.Show(this);
        }
        private void FillList()
        {   
            textBox1.Text = fi.Value; // grab whatever value the input form has
        }
    }
