    private DataTable LoadExcelData(string fileName)
{
    string Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";";
    OleDbConnection con = new OleDbConnection(Connection);
    OleDbCommand command = new OleDbCommand();
    DataTable dt = new DataTable(); OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [Sheet1$] WHERE LastName <> '' ORDER BY LastName, FirstName", con);
    myCommand.Fill(dt);
    Console.WriteLine(dt.Rows.Count);
    return dt;
