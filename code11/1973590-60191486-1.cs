	internal class Program
	{
		public DateTime DesiredBookingDate
		{
			get;
			set;
		}
		[STAThread]
		private static void Main()
		{
		}
		public Program()
		{
			this.<DesiredBookingDate>k__BackingField = DateTime.Now.Date;
			base..ctor();
		}
	}
