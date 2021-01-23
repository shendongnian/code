	// ------------------------------------------------------------------------
	public class MyTimeRange : TimeRange
	{
		// ----------------------------------------------------------------------
		public MyTimeRange( int id, DateTime start, DateTime end ) :
			base( start, end )
		{
			Id = id;
		} // TimeRange		
		// ----------------------------------------------------------------------
		public int Id { get; private set; }
		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return Id + ": " + base.ToString();
		} // ToString
	} // MyTimeRange
