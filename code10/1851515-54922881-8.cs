    using System;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form1 : Form
		{
			public delegate void OnLedChangedEventHandler(object sender, LedEventArgs e);
			public event OnLedChangedEventHandler OnLedChanged;
			public class LedEventArgs : EventArgs
			{
				public bool IsGreen { get; set; }
			}
			public Form1()
			{
				InitializeComponent();
				var form2 = new Form2(this);
				form2.Show();
			}
			private void ChangeLedState(bool status)
			{
				if (null != OnLedChanged) OnLedChanged(this, new LedEventArgs { IsGreen = status });
			}
			private void button1_Click(object sender, EventArgs e)
			{
				ChangeLedState(true);
			}
		}
	}
