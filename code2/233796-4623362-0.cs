    string data = System.IO.File.ReadAllText("myfile.txt");
    
    DataRow row = null;
    DataSet ds = new DataSet();
    DataTable tab = new DataTable();
    
    tab.Columns.Add("First");
    tab.Columns.Add("Second");
    
    string[] rows = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string r in rows)
    {
        string[] columns = r.Split(new char[] { '\t' },   StringSplitOptions.RemoveEmptyEntries);
        if (columns.Length <= tab.Columns.Count)
        {
            row = tab.NewRow();
    
            for (int i = 0; i < columns.Length; i++)
                row[i] = columns[i];
    
             tab.Rows.Add(row);
         }
     }
    
     ds.Tables.Add(tab);
