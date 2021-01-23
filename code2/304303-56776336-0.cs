            try
            {
                string filesName = "";
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                if(extenstype == ".pdf")
                {
                    filesName = Path.GetTempFileName();
                    
                }
                else
                {
                    filesName = Path.GetTempFileName() + extenstype;
                }
                 
           
                SqlCommand cmd = new SqlCommand("GetTestReportDocuments", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReportID", reportid);
               
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    while (dr.Read())
                    {
                        int size = 1024 * 1024;
                        byte[] buffer = new byte[size];
                        int readBytes = 0;
                        int index = 0;
                        using (FileStream fs = new FileStream(filesName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                            {
                                fs.Write(buffer, 0, readBytes);
                                index += readBytes;
                            }
                        }
                    }
                }
                Process prc = new Process();
                prc.StartInfo.FileName = filesName;
                prc.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //daDiagnosis.Dispose();
                //daDiagnosis = null;
            }
        }
