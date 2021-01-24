    void Main()
    {
	//init. table 
	System.Data.DataTable tbl = new DataTable();
	tbl.Columns.AddRange(new DataColumn[] {new DataColumn("Retailer"),
    new DataColumn("Brand"),
    new DataColumn("WK1-600"),
    new DataColumn("WK2-700"),new DataColumn("WK3-800")});
	
	//go over columns and rename
	foreach (DataColumn dc in tbl.Columns)
	{
		if(dc.ColumnName.Contains("WK")){
			dc.ColumnName = dc.ColumnName.Split('-')[1];
		}
	}
	//verifiyng the result
	  foreach (DataColumn dc in tbl.Columns)
	  {
		
			Console.WriteLine(dc.ColumnName);
	  }
    }
