	[ContentProperty("Hours")]
	public partial class TimeBox : UserControl
	{
		public string Hours
		{
			get { return this.TBHours.Text; }
			set { this.TBHours.Text = value; }
		}
		...
	}
