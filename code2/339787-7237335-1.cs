    public static IEnumerable<int> GetAllVendors()
    {
        using (var cmd = Data.GetCommand(Configuration.DatabaseOwnerPrefix + ".GetAllInformationAndHelpVendorIds", Connections.MyDbConnection))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetInt32(0);
                }
            }
        }
    }
