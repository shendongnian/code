    List<ArrayList> newval = new List<ArrayList>();
        foreach (DataRow dRow in ds.Tables[0].Rows)
          {
            ArrayList values = new ArrayList();
            foreach (object value in dRow.ItemArray)
                values.Add(value);
                newval.Add(values);
          }
     newpath = newval;
