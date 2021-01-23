	// ------------------------------------------------------------------------
	public class Customer
	{
		// ----------------------------------------------------------------------
		[Category( "Editable Values" ), LocDescription( "FirstName", "Sets the first name..." )]
		public string FirstName { get; set; }
		// ----------------------------------------------------------------------
		[Category( "Editable Values" ), LocDescription(  Key = "LastName", DefaultDescription = "Sets the last name..." )]
		public string LastName { get; set; }
	} // class Customer
