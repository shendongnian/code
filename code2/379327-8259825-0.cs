    private void ExecuteScripts(string dir, bool useTransaction = true, bool useMasterConnection = false)
    {
        foreach (var file in SqlFiles.Where(x => x.Contains(dir)))
        {
            var resource = file.Substring((Assembly.GetExecutingAssembly().GetName().Name + ".scripts.").Length);               
            if (useTransaction)
                ExecuteSqlWithTransaction(resource, useMasterConnection);
            else
                ExecuteSqlWithoutTransaction(resource, useMasterConnection);
        }
    }
     private void ExecuteSqlWithoutTransaction(string sqlFile, bool useMasterConnection = false)
            {
                var sql = string.Empty;
    
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream((Assembly.GetExecutingAssembly().GetName().Name + ".scripts.") + sqlFile.Replace('\\', '.'));
    
                using (var reader = new StreamReader(stream))
                {
                    sql = reader.ReadToEnd();
                }
    
                // replace the [[[dbName]]] and [[[SQLDATAFILEPATH]]] with ACTUAL DB settings we want to work with
                sql = sql.Replace("[[[DBNAME]]]", DbName);
                sql = sql.Replace("[[[SQLDATAFILEPATH]]]", SqlDataFilePath);
    
                var regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                var lines = regex.Split(sql);
    
                var currentConnection = (useMasterConnection) ? MasterSqlConnection : SqlConnection;
    
                using (var cmd = currentConnection.CreateCommand())
                {
                    cmd.Connection = currentConnection;
    
                    foreach (var line in lines)
                    {
                        if (line.Length > 0)
                        {
                            cmd.CommandText = line;
                            cmd.CommandType = CommandType.Text;
    
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                //ShowInfo("Error running script " + sqlFile + "    Error: " + ex.Message);
                                throw new Exception(ex.Message);
                            }
                        }
                    }
                }
    
            }
    ALTER TABLE [dbo].[ArticleProjectAssignments] ADD  CONSTRAINT [pk_ArticleProjectAssignments] PRIMARY KEY CLUSTERED 
    (
    	[ArticleId] ASC,
    	[ProjectId] ASC
    )
    GO
