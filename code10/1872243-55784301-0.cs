    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pet cat = new Pet("10", "Fido", "Cat");
  
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = cat.GetName();
        }
    }
