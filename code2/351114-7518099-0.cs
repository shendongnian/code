    bool compareTbls(Datatable tbl1, Datatable tbl2)
    {
      if(tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
        return false;
    
      for(int i = 0; i < tbl1.Rows.Count; i++)
      {
        for(int c = 0; c < tbl.Columns.Count; c++)
        {
          if(tbl1.Rows[i][c] != tbl2.Rows.Columns[i][c])
            return false;
        }
      }
      return true;
    }
