	IEnumerable<IDocument> items;
    items = GetDocumentsOfType1();
	public static IEnumerable<IDocument> GetDocumentsOfType1()
	{
		return new List<Doc1>() { new Doc1() };
	}
    // (etc)
