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
                    // EDIT: Perhaps you can get access the "Authority Table" here as well? e.g.
                    DataTable AuthorityTable = result.Tables["AuthoritySheet"];
                    // I'll try to do something equivalent
                    //DataTable newDt = dt.Select().Skip(1).Take(dt.Rows.Count).CopyToDataTable();
                    DataTable newDt = dt.Clone();
                    bool firstRow = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Id"] != null && !firstRow && AuthorityContainsKey(Convert.ToInt32(dr["Id"]), AuthorityTable))
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
    public bool AuthorityContainsKey(int id, DataTable Auth)
    {
        bool result = false;
        foreach (DataRow dr in Auth.Rows)
        {
            if (dr["Id"] != null && Convert.ToInt32(dr["Id"]) == id)
                return true;
        }
        return result;
    }
