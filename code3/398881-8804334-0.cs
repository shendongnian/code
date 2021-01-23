                SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.CommandText = "EXEC  master.dbo.xp_instance_regread  N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer',N'BackupDirectory'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = myConnection;
                myConnection.Open();
                SqlDataReader myDataReader = cmd.ExecuteReader();
    
                myDataReader.Read();
                string backupFolder = myDataReader.GetString(1);
