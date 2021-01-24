    try 
	{	        
	    var xlsDbPath= "C:\\Temp\\Test.xls"; //<-- Full name of path
        var connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + xlsDbPath+ ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
        var query = "SELECT * FROM [Sheet1$] WHERE [Staff Number] = 1234";  //<-- Add $ after Sheet1 and fix 'Staff Number'?
                
        using (var con = new OleDbConnection(connStr))
        {
            con.Open();
            using (var oleDbCommand = new OleDbCommand(query, con))
            {
                using (var oleDbDataReader = oleDbCommand.ExecuteReader())
                {
                    while (oleDbDataReader.Read())  //Read through results
                    {
                         TxtDateOfBirth.Text = oleDbDataReader.GetString(1);
                         TxtName.Text = oleDbDataReader.GetString(2);
                         //...  //Remember if value is not string you will get error
                         //...  //so if not string use .GetValue(1).ToString();
                    } 
                }
            }
        }
    }
    catch (Exception ex)
	{
        MessageBox.Show(ex.ToString());
	}
