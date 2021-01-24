	var appClass = new ApplicationClass();
	appClass.Visible = false;
	appClass.UserControl = false;
	appClass.OpenCurrentDatabase(@"C:\RadLokal\trunk\Test\Access\Test.accdb", false, "");
	var db = appClass.CurrentDb();
	var queryDefs = db.QueryDefs;
	for (int i = 0; i < queryDefs.Count; i++)
	{
		var item = queryDefs[i];
		const string QueryPrefix = "Query_";
		var filename = Path.Combine(@"c:\Temp", QueryPrefix + item.Name + ".txt");
		File.WriteAllText(filename, item.SQL);
		item.Close();
		item = null;
	}
	queryDefs = null;
	db.Close();
	db = null;
	appClass.CloseCurrentDatabase();
	appClass.Quit(AcQuitOption.acQuitSaveNone);
	appClass = null;
	GC.Collect();
