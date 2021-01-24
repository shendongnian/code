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
**Breakdown of the important changes:**  
.ToDictionary(p => p.Key, p => p.Value);
instead of 
.ToDictionary(pair => new jsonOutputStyle() { 
   Name = pair.Key, 
   Value = pair.Value
});
Here we first need to get a simple dictionary with `string` as key and `string` as value. We do this by using two selectors. One for the key (`p => p.Key`) and one for the value (`p => p.Value`). We don't need to worry about serializing yet.  
Now for serializing we don't directly serialize the dictionary but instead, cast the dictionary to an array of your tupel-type. This allows us to serialize the names **you** defined in that class and not pre-defined property-names.
jsonOutputStyle[] styledDictionary = _dicts.Select(p => new jsonOutputStyle() { Name = p.Key, Value = p.Value }).ToArray();
return JsonConvert.SerializeObject(styledDictionary, Formatting.None);
Also [right here](https://stackoverflow.com/a/12555718/10883465) is the answer to a very similar question which essentially does the same thing I just showed you.
