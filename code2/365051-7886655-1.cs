	// Code from Form 1
	public partial class Form1 : Form
	{
		public string MyValue { get; set; }
		
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Form2 objForm2 = new Form2();
			objForm2.textBox1.Text = MyValue;
			objForm2.MainForm = this;
			objForm2.Show();
		}
	}
	// Code From Form 2
	public partial class Form2 : Form
	{
		public Form1 MainForm { get; set; }
		public Form2()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			MainForm.MyValue = textBox1.Text;
			MainForm.Show();
			this.Close();
		}
	}
