	public partial class timerangeResult
	{
		
		private int _ID;
		
		private string _Login;
		
		private System.DateTime _Starts;
		
		private System.DateTime _Ends;
		
		private string _Delete;
		
		private byte _Notify;
    // CUSTOM
    //public static explicit operator List<Booking>(timerangeResult t)
    public static List<Booking> ToBookingList(IEnumerable<timerangeResult> t)
    {
        List<Booking> bL = new List<Booking>();
        IEnumerable<timerangeResult> tx = (IEnumerable<timerangeResult>)t;
        foreach (timerangeResult tt in tx)
        {
            Booking b = (Booking)tt;
            bL.Add(b);
        }
        return bL;
    }
    // CUSTOM END^
