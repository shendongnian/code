        var values = new List<string>();
        while (reader.Read())
        {
          values.add(rdr.GetString(1));
        }
        
        int i = 0;
        foreach (GridViewRow row in gridViewIdHere.Rows)
        {
            ((Label)row.FindControl("category_id")).Text = values[i];
            i++;
        }
