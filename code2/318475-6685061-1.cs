        public partial class Form2 : Form
    {
        public bool c;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = c;
        }
    }
