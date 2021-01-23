	public static void GetFields(this SPListItem item)
	{
		var test=item[new Guid("{0B72A4E1-FFFF-4D45-B07A-197D46D2989C}")];
		var collection=new SPFieldLookupValueCollection(test.ToString());
	}
