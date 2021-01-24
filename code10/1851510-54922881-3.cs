    using System;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form2 : Form
		{
			public Form2(Form1 form1)
			{
				form1.OnLedChanged += (object sender, Form1.LedEventArgs e) =>
				{
					var status = e.Status;
					// TODO: Change the LED on Form2 accordingly
				};
			}
		}
	}
