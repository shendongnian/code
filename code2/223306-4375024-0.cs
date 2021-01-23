    public DataSet GetCSVFile(string fileName)
    {
    
        string pathName = "\\\\td47vc\\public\\Joe\\ASP\\Test";
        string file = System.IO.Path.GetFileName(fileName);
        OleDbConnection excelConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties=Text;");
        OleDbCommand excelCommand = new OleDbCommand(@"SELECT * FROM " + file, excelConnection);
        OleDbDataAdapter excelAdapter = new OleDbDataAdapter(excelCommand);
        excelConnection.Open();
        DataSet ds = new DataSet();
        excelAdapter.Fill(ds);
        excelConnection.Close();
        return ds;
    }
