    string[] lines = File.ReadAllLines("myfile");
    
    Dictionary<string, int> totals = new Dictionary<string, int>();
    foreach (string line in lines)
    {
      string[] fields = line.Split("|");
      if (!totals.ContainsKey(fields[0])
      {
        totals[fields[0]] = 0;
      }
      totals += Convert.ToInt32(fields[1]);
    }
    
    foreach (KeyValuePair<int, string> total in totals)
    {
      Console.WriteLine("{0}|{1}", total.Key, total.Value);
    }
