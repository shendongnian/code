    private static Dictionary<int, string>
                FindMatches(string queryFormat,
                            string region,
                            string type,
                            string label)
    {
        var records = new Dictionary<int, string>();
        var query = string.Format(queryFormat, SqlSvrName, SqlDbName,
                                  SqlSchemaName, region, type, label);
        using (var dr = DataRepository.Provider.ExecuteReader(CommandType.Text,
                                                              query))
        {
            if (dr != null && !dr.IsClosed)
            {
                while (dr.Read())
                {
                    var assetID = (int)dr.GetDouble(0);
                    // If each assetID in the database will be distinct, you 
                    // don't need the "if" here, because you know the dictionary
                    // is empty to start with
                    if (!records.ContainsKey(assetID))
                    {
                        records[assetID] = dr.GetString(1);
                    }
                }
            }
        }
        return records;
    }
