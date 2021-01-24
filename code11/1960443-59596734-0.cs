csharp
private List<List<string>> Process(DataSet ds, int pageSize)
{
	List<List<string>> result = new List<List<string>>();
	int COunt = ds.Tables[0].DefaultView.Count;
	int NoOfArraysToCreate = COunt / pageSize + 1;
	IEnumerable<DataRow> collection = ds.Tables[0].Rows.Cast<DataRow>(); //I find it easier to work with enumerables as it allows for LINQ expressions as below
	
	for (int i = 0; i < NoOfArraysToCreate; i++)
	{
		result.Add(collection.Skip(i*pageSize)
				.Take(pageSize)
				.Select(r => r["Url"].ToString())
				.ToList());
	}
	
	return result;//I see you convert your string arrays back to DataSet, but since I don't know the table definition, I'm just returning the lists
}
void Main()
{
	// this is just a test code to illustrate my point, yours will be different
	var ds = new DataSet();
	var dt = new DataTable();
	dt.Columns.Add("Url", typeof(string));
	for (int i = 0; i < 34; i++) {
		dt.Rows.Add(Guid.NewGuid().ToString());//generating some random strings, ignore me
	}
	ds.Tables.Add(dt);
	//---------------------------------------
	Process(ds, 10);// calling your method
}
of course there are ways to do it with for loops as well, but I'd leave that for you to explore. 
I would also say hardcoding table numbers into your method usually is considered a code smell, but since I don't know your context I will not make any further changes
