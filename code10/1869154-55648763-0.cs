private void WriteSQLQueryOutputToTextFile(string DBUser, string DBUserPassword, string sqlQuery, string databaseName, string nameOfOutputFile)
{
    string pathOfOutputFile = dWTestResult + "\\DatabaseUpgradeCheck\\" + nameOfOutputFile;           
    using (SqlConnection sqlCon = new SqlConnection("Data Source=" + 
    GetEnvironmentVariable.MachineName + "; Initial Catalog=" + databaseName + "; User ID=" + DBUser + "; Password=" + DBUserPassword + ";"))
    {
        SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, sqlCon);     
        try
        {
          sqlCon.Open();
          DataSet dataset = new DataSet();
          adapter.Fill(dataset, "nameOfDataset");
          string currentLine = "";
          var nameLengths = new int[dataset.Tables[0].Columns.Count];
          var i = 0;
          foreach (var col in dataset.Tables[0].Columns)
          {
            var colName = col.ToString();
            nameLengths[i] = colName.Length;
            currentLine += " " + col.ToString();
            i++;
          }
         OutputHandler.AppendDataToFile(pathOfOutputFile, currentLine);
         foreach (DataRow row in dataset.Tables[0].Rows)
         {
            currentLine = "";
            i = 0;
            foreach (var item in row.ItemArray)
            {
                var field = item.ToString();
                currentLine += " " + field.PadRight(nameLengths[i], ' ');
                i++;
            }
            OutputHandler.AppendDataToFile(pathOfOutputFile, currentLine);
          }
     }
     catch (Exception ex)
     {
        logger.Debug(ex, "Writing Database Output to the " + "\"" + nameOfOutputFile + "\"" + " file failed");
     }
     finally
     {
        sqlCon.Close();
     }
   }
}
