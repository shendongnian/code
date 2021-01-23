     public partial class Form2 : Form
    {
        public string ReturnText { get; set; }
        public Form2()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.ReturnText = this.textBox1.Text;
            this.Visible = false;
        }
    }
