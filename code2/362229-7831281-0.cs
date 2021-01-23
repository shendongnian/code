        #region
        using (StreamReader sr = new StreamReader(sourcePath))
        {
            using (StreamWriter sw = new StreamWriter(ResultPath))
            {
                sw.WriteLine(@"DECLARE @er NVARCHAR(MAX)='',@i INT=0 BEGIN  TRY");
                if (sr.Peek() >= 0)
                {
                    string currentLine = sr.ReadLine();
                    
                    while (currentLine.Trim() == "" && sr.Peek() >= 0)
                        currentLine = sr.ReadLine();
                    if (currentLine.Trim() == "")
                    {
                        //error :the file is empty
                    }
                    sw.WriteLine(currentLine);
                }
                while (sr.Peek() >= 0)
                {
                    string currentLine = sr.ReadLine();
                    
                    if (currentLine.Trim() == "")
                        continue;
                    if (currentLine.Trim().StartsWith("INSERT"))
                    {
                        while (!currentLine.Trim().StartsWith("INSERT"))
                            currentLine += sr.ReadLine();
                        currentLine = @"END TRY
                                                        BEGIN CATCH
        	                                            SELECT @er+=','+LTRIM(RTRIM(STR(ERROR_LINE()))),@i+=1
                                                    END CATCH BEGIN  TRY" + Environment.NewLine + currentLine.Trim();
                    }
                    sw.WriteLine(currentLine.Trim());
                }
                sw.WriteLine(@"END TRY
                                            BEGIN CATCH
        	                                SELECT @er+=','+LTRIM(RTRIM(STR(ERROR_LINE())))
                                        END CATCH SELECT @er AS errorLines,@i AS errorCount");
                sw.Close();
                sr.Close();
            }
        }
        #endregion
        ExecuteConvertedFile(ResultPath,Server.MapPath(@"~/Data/Uploads/csv/ErrorLogs/ErrorLog.sql"));
    }
    void ExecuteConvertedFile(string ResultPath, string errorResultPath)
    {
        string wholeQuery = System.IO.File.ReadAllText(ResultPath);
        using (SqlCommand cmd = new SqlCommand { CommandType = CommandType.Text, CommandText = wholeQuery, Connection = new SqlConnection(((SqlConnection)((EntityConnection)new NezaratEntities().Connection).StoreConnection).ConnectionString) })
        {
            cmd.Connection.Open();
            var dr = cmd.ExecuteReader();
            dr.Read();
            WriteErrorLogs(ResultPath,errorResultPath,dr["errorLines"].ToString().Trim());
            Label1.Text = dr["errorCount"].ToString()+"unsuccessful transactions";
        }
    }
