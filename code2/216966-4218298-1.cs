    Dictionary<string, int> totals = new Dictionary<string, int>();
    foreach (string line in lines)
    {
      string[] fields = line.Split(new char[]{'|'});
      if (!totals.ContainsKey(fields[0]))
      {
        totals[fields[0]] = 0;
      }
      totals[fields[0]] += Convert.ToInt32(fields[1]);
    }
    
    foreach (KeyValuePair<string, int> total in totals)
    {
      Console.WriteLine("{0}|{1}", total.Key, total.Value);
    }
