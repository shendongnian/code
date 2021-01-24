    List<string> names= new List<string>();
    foreach(var row in table.Rows)
    {
      if(names.Contains(row["name"])
      {
      names.Add(row["name"].ToString());
      }
    else
    {
       DataRow dr = match.NewDataRow();
       dr.ItemArray=row.ItemArray; match.Rows.Add(dr);
    }
    }
