    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    
    
    string outputFolder = Dts.Variables["User::OutputFolder"].Value.ToString();
    string filePrefix = Dts.Variables["User::FilePrefix"].Value.ToString();
    
    DirectoryInfo di = new DirectoryInfo(outputFolder);
    List<string> currentExecutionFiles = new List<string>();
    
    string connectionStr = @"Data Source=Server;Initial Catalog=Database;Integrated Security=SSPI;";
    string cmd = @"SELECT [FILENAME] FROM DATABASE.SCHEMA.FILES";
    
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        using (SqlCommand sql = new SqlCommand(cmd, conn))
        {
            conn.Open();
            using (SqlDataReader dr = sql.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //get file names from table holding names from current execution
                        currentExecutionFiles.Add(dr[0].ToString());
                    }               
                }
            }
        }
    }
    
    foreach (FileInfo fi in di.EnumerateFiles())
    {
        //check for file with prefix (case insensitive) that was not in current execution
        if (fi.Name.StartsWith(filePrefix, StringComparison.InvariantCultureIgnoreCase)
                            && !currentExecutionFiles.Contains(fi.Name))
        {
            fi.Delete();
        }
    }
