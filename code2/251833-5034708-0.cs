    private static void
                FindMatches(ref Dictionary<int, string> records,
                            string queryFormat,
                            string region,
                            string type,
                            string label)
    {
        var query = string.Format(queryFormat, SqlSvrName, SqlDbName, SqlSchemaName,
                                                                 region, type, label);
        using (var dr = DataRepository.Provider.ExecuteReader(CommandType.Text, query))
        {
            if (dr != null && !dr.IsClosed)
            {
                while (dr.Read())
                {
                    var assetID = (int)dr.GetDouble(0);
                    if (!records.ContainsKey(assetID))
                        records[assetID] = dr.GetString(1);
                }
            }
        }
    }
