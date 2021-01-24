    string connectionstring;
    DataTable dtexcel2 = new DataTable();
    connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES';";
    OleDbConnection connection = new OleDbConnection(connectionstring);
    OleDbCommand command = new OleDbCommand("Select * From [POSFailures$]  WHERE Date = ?");
    command.Parameters.Add(DateTime.Now.ToString("MM/dd/yyyy"));
    command.Connection = connection;
    try
    {
        connection.Open();
        OleDbDataAdapter sda = new OleDbDataAdapter(command);
        sda.Fill(dtexcel2);
        connection.Close();
    }
    catch (Exception)
    {
    }
