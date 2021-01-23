    var reader = new StreamReader(File.OpenRead(@"d:\er.txt"));
    var table = new DataTable("SampleTable");
    int columnCount = 0;
    while (!reader.EndOfStream)
    {
      var line = reader.ReadLine().Trim();
      var values = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
      string[] ee = values;
      while (columnCount < ee.Length) 
      {
        // Only add a new column if it's required.
        table.Columns.Add();
        columnCount++;
      }
      var newRow = table.NewRow();
      for (int i = 0; i < ee.Length; i++)
      {
          newRow[i] = ee[i].Trim().ToString(); // like sample [0,0]
      }
      table.Rows.Add(newRow);
    }
