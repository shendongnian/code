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
				public bool Status { get; set; }
			}
			private void ChangeLedState(bool status)
			{
				if (null != OnLedChanged) OnLedChanged(this, new LedEventArgs { Status = status });
			}
		}
	}
