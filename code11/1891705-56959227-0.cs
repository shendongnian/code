    void Main()
    {
    	var table = SendQuery("select id, ext, cast(filedata as blob) as filedata from imageData");
    	
    	foreach (DataRow row in table.Rows)
    	{
    		var bytes = (byte[])row["filedata"];
    		var id = (int)row["id"];
    		var ext = (string)row["ext"];
    
    		File.WriteAllBytes(Path.Combine(@"c:\temp", $"test_image{id}.{ext.Trim()}"),bytes);
    	}
    }
    
    public DataTable SendQuery(string query)
    {
    	string cnStr = @"Provider=vfpoledb;Data Source=C:\Temp;";
    	try
    	{
    		DataTable tbl = new DataTable();
    		new OleDbDataAdapter(query, cnStr).Fill(tbl);
    		return tbl;
    	}
    	catch (OleDbException e)
    	{
    		MessageBox.Show(e.Message + "\nWith error" + e.ErrorCode, "Error de base de datos");
    	}
    	catch (Exception e)
    	{
    		MessageBox.Show(e.Message, "Error general");
    	}
    	return null;
    }
