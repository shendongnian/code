[Obsolete]
public string POB_CODE()
{
    Dictionary<string, string> _dicts = null;
    try
    {
        using (OracleConnection Oconn = new OracleConnection(connectionORI))
        {
            _dicts = Oconn.Query<KeyValuePair<string, string>>(
                                "SELECT " +
                                    "POB_CODE AS Key," +
                                    "POB_DESC AS Value " +
                                "FROM " +
                                    "POB_CODE " +
                                "WHERE " +
                                    "DISPLAY_SORT_ORDER >=1 " +
                                "AND " +
                                    "DISPLAY_SORT_ORDER <=60",
                                null
                            )
                    .ToDictionary(p => p.Key, p => p.Value);
        }
    }
    catch (SqlException ex)
    {
        System.Diagnostics.Debug.WriteLine(ex.Message);
    }
    jsonOutputStyle[] styledDictionary = _dicts.Select(p => new jsonOutputStyle() { Name = p.Key, Value = p.Value }).ToArray();
    return JsonConvert.SerializeObject(styledDictionary, Formatting.None);
}
