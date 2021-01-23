    var query = from e in doc.Root.Elements( ns + "TestEntries" ).Elements()
				where e.Attribute( "testListId" ).Value == "L1"
				select new
				{
				    TestId = e.Attribute( "testId" ).Value,
				    ExecutionId = e.Attribute( "executionId" ).Value
				};
	foreach ( var testEntry in query )
	{
		Console.WriteLine( testEntry.TestId + " " + testEntry.ExecutionId );
	}
