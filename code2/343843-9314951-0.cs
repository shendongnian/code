    //Declare a class that inherits from ToolStripControlHost.
	public class ToolStripCustomCombo : ToolStripControlHost
	{
		// Call the base constructor passing in a MonthCalendar instance.
		public ToolStripCustomCombo() : base(new ComboBox()) { }
		public ComboBox ComboBox
		{
			get
			{
				return Control as ComboBox;
			}
		}
	}
