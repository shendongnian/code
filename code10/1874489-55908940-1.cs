    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    
    string currentFile = Dts.Variables["User::FileNameVariable"].Value.ToString();
    FileInfo currentFileInfo = new FileInfo(currentFile);
    //Integrated Security for Windows authentication
    string connectionStr = @"Data Source=Server;Initial Catalog=Database;Integrated Security=SSPI;";
    string cmd = @"INSERT INTO DATABASE.SCHEMA.FILES ([FILENAME]) VALUES (@file)";
    
     using (SqlConnection conn = new SqlConnection(connectionStr))
     {
         using (SqlCommand sql = new SqlCommand(cmd, conn))
         {
             SqlParameter pFileName = new SqlParameter("@file", SqlDbType.VarChar);
             pFileName.Direction = ParameterDirection.Input;
             pFileName.Size = 250;
             //use FileInfo.Name to get only file path
             pFileName.Value = currentFileInfo.Name;
             sql.Parameters.Add(pFileName);
             conn.Open();
             //insert file name
             sql.ExecuteNonQuery();
         }
     }
