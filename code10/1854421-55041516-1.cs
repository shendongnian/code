	using System;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void btnApp1_Click(object sender, EventArgs e)
			{
				var f = new WindowsFormsApplication2.Form1();
				f.ShowDialog();
			}
			private void btnApp2_Click(object sender, EventArgs e)
			{
				var f = new WindowsFormsApplication3.Form1();
				f.ShowDialog();
			}
		}
	}
