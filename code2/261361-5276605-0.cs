        public static void RunBackup(string dbName, string filePath, string backupName, string connString)
        {
            string commmandText = "BACKUP DATABASE @DBName TO  DISK = @FilePath WITH NOFORMAT, NOINIT, NAME = @BackUpName, SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlConnection objConnection = new SqlConnection(connString);
            try
            {
                SqlCommand objCommand = new SqlCommand(commmandText, objConnection);
                objCommand.Parameters.AddWithValue("@dbName", dbName);
                objCommand.Parameters.AddWithValue("@FilePath", filePath);
                objCommand.Parameters.AddWithValue("@BackUpName", backupName);
                objConnection.Open();
                IAsyncResult result = objCommand.BeginExecuteNonQuery();
                while (!result.IsCompleted)
                {
                    System.Threading.Thread.Sleep(100);
                }
                int count = objCommand.EndExecuteNonQuery(result);
             }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                objConnection.Close();
                 
            }
            
        }
