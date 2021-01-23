    public void CreateCSVFile(ref DataTable dt, string strFilePath)
                {            
                    try
                    {
                        // Create the CSV file to which grid data will be exported.
                        StreamWriter sw = new StreamWriter(strFilePath, false);
                        // First we will write the headers.
                        //DataTable dt = m_dsProducts.Tables[0];
                        int iColCount = dt.Columns.Count;
                        for (int i = 0; i < iColCount; i++)
                        {
                            sw.Write(dt.Columns[i]);
                            if (i < iColCount - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.Write(sw.NewLine);
        
                        // Now write all the rows.
        
                        foreach (DataRow dr in dt.Rows)
                        {
                            for (int i = 0; i < iColCount; i++)
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                {
                                    sw.Write(dr[i].ToString());
                                }
                                if (i < iColCount - 1)
                                {
                                    sw.Write(",");
                                }
                            }
        
                            sw.Write(sw.NewLine);
                        }
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
