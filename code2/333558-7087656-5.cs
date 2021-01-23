    IEnumerable<IDataRecord> SearchMyTable(string[] filters)
    {
        var results = EnumerableFromDataReader(GetMyTable());
        foreach (string filter in filters)
        {
           results = results.Where(r => String.Join("",r.GetValues.Cast<string>().ToArray()).Contains(filter);
        }
  
        return results;
    }
