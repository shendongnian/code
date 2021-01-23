     public partial class Form2 : Form
    {
        public string MyProperty { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = MyProperty;
        }
    }
