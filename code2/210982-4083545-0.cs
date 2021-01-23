	public partial class Form1 : Form
	{
		ContextMenu blah = new ContextMenu();
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			textBox1.ContextMenu = blah;
		}
	}
