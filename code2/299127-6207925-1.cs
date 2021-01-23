    public SortedList<int, DataRow> SortDataTableCollection(DataTableCollection col)
    {
      SortedList<int, DataRow> result = new SortedList<int, DataRow>();
      foreach(DataTable tbl in col)
      {
        foreach(DataRow rw in tbl.Rows)
        {
          result.Add((int)rw["JobNumber"], rw);
        }
      }
    }
