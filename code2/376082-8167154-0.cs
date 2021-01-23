	public partial class Form1 : Form
	{
		private string selectedListBox;
		public Form1()
		{
			InitializeComponent();
			
		}
	
		private void listBox1_Enter(object sender, EventArgs e)
		{
			selectedListBox = (sender as ListBox).Name;
		}
	}
