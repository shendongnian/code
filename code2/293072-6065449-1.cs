		using System.Configuration;
		using System.Windows.Forms;
		namespace SO6065319
		{
				public partial class Form1 : Form
				{
						public Form1()
						{
								InitializeComponent();
								textBox1.Text = ConfigurationManager.AppSettings["myKey"];
						}
				}
		}
			
