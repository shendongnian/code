//using System.Data.OleDb;
private static void OpenMyExcel()
{
    string filePath = "C:\\users\\me\\Desktop\\Book1.xlsx";
    OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0\"");
    
    try
    {
        connection.Open();
        //Do stuff
    }
    catch(Exception e)
    {
        //has a password
    }
}
