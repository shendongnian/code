        public bool ExtractExcelToDB(int activityId, string tableName, string fileName)
        {
            try
            {
                var path = GetPath(activityId);
                path = Path.Combine(path, fileName);
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        DataSet result = excelReader.AsDataSet();
                        DataTable dt = result.Tables["sheet"];
                        // I'll try to do something equivalent
                        //DataTable newDt = dt.Select().Skip(1).Take(dt.Rows.Count).CopyToDataTable();
                        DataTable newDt = dt.Clone();
                        bool firstRow = true;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Id"] != null && !firstRow)
                                newDt.Rows.Add(dr);
                            else
                                firstRow = false;
                        }
                        using (SqlBulkCopy sqlBulk = new SqlBulkCopy(GetConnectionString()))
                        {
                            sqlBulk.DestinationTableName = tableName;
                            sqlBulk.WriteToServer(newDt);
                        }
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
         }
