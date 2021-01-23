    string strConnection = "";<br/>
    
    string FileName = Server.MapPath("Student.xls");
        
    strConnection = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties='Excel 8.0; HDR=Yes;IMEX=1;'";<br/>
        
    try
    {
    	OleDbConnection conn1 = new OleDbConnection(strConnection);
    	conn1.Open();
    	DataTable dt = new DataTable();
    	dt = conn1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
    
    	Object sheetName = dt.Rows[0]["TABLE_NAME"];
    	dt.Clear();
    	dt.Columns.Clear();
    	OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName.ToString() + "]", conn1);
    	da.TableMappings.Add("Table", "0");
    	da.Fill(dt);
    
    	for (int i = 0; i < dt.Rows.Count; i++)
    	{
    		string ID = dt.Rows[i][0].ToString();
    		string Name = dt.Rows[i][1].ToString();
    		string City = dt.Rows[i][2].ToString();
    		string Marks = dt.Rows[i][3].ToString();
    	}
    	conn1.Close();
    }
    catch
    {
    	throw;
    }
    //To Read xlsx file use following code
    string strConnection = "";  <br/>
    string FileName = Server.MapPath("Student.xlsx"); <br/>
    strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0 Xml;HDR={1};IMEX=1;'";<br/>
    
    try
    {
    	OleDbConnection conn1 = new OleDbConnection(strConnection);
    	conn1.Open();
    
    	DataTable dt = new DataTable();
    	dt = conn1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
    
    	Object sheetName = dt.Rows[0]["TABLE_NAME"];
    	dt.Clear();
    	dt.Columns.Clear();
    	OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName.ToString() + "]", conn1);
    	da.TableMappings.Add("Table", "0");
    	da.Fill(dt);
    	//int idx=0;
    	//int j=0;
    	for (int i = 0; i < dt.Rows.Count; i++)
    	{
    		string ID = dt.Rows[i][0].ToString();
    		string Name = dt.Rows[i][1].ToString();
    		string City = dt.Rows[i][2].ToString();
    		string Marks = dt.Rows[i][3].ToString();
    	}
    
    	conn1.Close();
    }
    catch
    {
    	throw;
    }
