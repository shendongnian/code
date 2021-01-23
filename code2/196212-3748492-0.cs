    DataTable MakeDataTable(String name, String contents)
    {
      DataTable dt = new DataTable(name);
      foreach (string val in contents.Split(","))
      {
        DataRow dr = dt.NewRow();
        dr[0] = val;
        dt.Rows.Add(dr);
      }
      return dt;
    }
    MakeDataTable("results","Sydney,Perth,Darwin");
