	// ------------------------------------------------------------------------
	public class LocDescriptionAttribute : DescriptionAttribute
	{
		// ----------------------------------------------------------------------
		public LocDescriptionAttribute()
		{
		} // LocDescriptionAttribute
		// ----------------------------------------------------------------------
		public LocDescriptionAttribute( string key, string defaultDescription ) :
			base( defaultDescription )
		{
			Key = key;
			DefaultDescription = defaultDescription;
		} // LocDescriptionAttribute
		// ----------------------------------------------------------------------
		public string Key { get; set; }
		// ----------------------------------------------------------------------
		public string DefaultDescription { get; set; }
		// ----------------------------------------------------------------------
		public override string Description
		{
			get
			{
				// load from resx
				string description = Strings.GetString( Key );
				if ( string.IsNullOrEmpty( description ) )
				{
					description = DefaultDescription;
				}
				return description;
			}
		} // Description
	} // class LocDescriptionAttribute
