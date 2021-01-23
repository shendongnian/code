    Dictionary<string, int> result = (from row in dt.AsEnumerable()
                              select new KeyValuePair<string, int>
                              (row.Field<string>("nameProduct"), row.Field<int>("price")))
                              .ToDictionary(p=>p.Key,p=>p.Value);
    
     foreach (var t in result)
      {
        Console.WriteLine(t.Key + " " + t.Value);
      }
