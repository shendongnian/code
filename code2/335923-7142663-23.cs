	// a dummy source class; this is just the parts that were relevant
	// to this particular discussion.
	public partial class ExchangeCommonDataSource
	{
		public string Username { get; set; }
		public string OptionalString { get; set; }
		public int MailboxNumber { get; set; }
 		public Guid SourceGuid { get; set; }
		public long BigNumber { get; set; }
		// these static members provide the functionality necessary to look
		// retrieve an existing source just through the class interface 
		// this holds the lookup of Guid -> Source for later retreival
		static Dictionary<Guid, ExchangeCommonDataSource> allSources = 
				new Dictionary<Guid,ExchangeCommonDataSource>();
		// this factory method looks up whether the source with the passed 
		// Guid already exists; if it does, it returns that, otherwise it
		// creates the data source and adds it to the lookup table
		public static ExchangeCommonDataSource GetConnection(
				Guid parSourceGuid, string parUsername, long parBigNumber
		)
		{
			// there are many issues involved with thread safety, I do not
			// guarantee that I got it right here, it's to show the idea. :)
			// here I'm just providing some thread safety; by placing a lock 
			// around the sources to prevent two separate calls to a factory
			// method from each creating a source with the same Guid. 
			lock (allSources)
			{
				ExchangeCommonDataSource RetVal;
				allSources.TryGetValue(parSourceGuid, out RetVal);
				if (RetVal == null)
				{
					// using member initializer, you can do this to limit the
					// number of constructors; here we only need the one 
					RetVal = new ExchangeCommonDataSource(parSourceGuid) {
						Username = parUsername, BigNumber = parBigNumber
					};
					allSources.Add(parSourceGuid, RetVal);
				}
				return RetVal;
			}
		}
		// this function is actually extraneous since the GetConnection 
		// method will either create a new or return an existing source.
		// if you had need to throw an exception if GetConnection was
		// called on for existing source, you could use this to retrieve
		public static 
			ExchangeCommonDataSource LookupDatasource(Guid parSourceGuid)
		{
			// again locking the sources lookup for thread-safety. the 
			// rules: 1. don't provide external access to allSources
			//        2. everywhere you use allSources in the class, 
			//           place a lock(allsources { } block around it
			lock (allSources)
			{
				ExchangeCommonDataSource RetVal;
				allSources.TryGetValue(parSourceGuid, out RetVal);
				return RetVal;
			}
		}
		// private constructor; it is private so we can rely on the 
		// fact that we only provide factory method(s) that insert the
		// new items into the main dictionary
		private ExchangeCommonDataSource(Guid SourceGuid) 
		{
			// if you didn't want to use a factory, you could always do
			// something like the following without it; note you will
			// have to throw an error with this implementation because 
			// there's no way to recover. 
			//lock (allSources)
			//{
			//   ExchangeCommonDataSource Existing; 
			//   ExchangeCommonDataSource.allSources.
			//      TryGetValue(parSourceGuid, out Existing);
			//   if (Existing != null)
			//      throw new Exception("Requested duplicate source!");
			//}
			// ... initialize ...
		}
	}
