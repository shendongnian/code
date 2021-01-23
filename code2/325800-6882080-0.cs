    private void AddColumns(GridView gv, string[] dateColumns)
    {
        for (int i = 0; i < dateColumns.Length; i++)
        {
            gv.Columns.Add(new GridViewColumn
            {
                Header = dateColumns[i],
                DisplayMemberBinding = new Binding(String.Format("[{0}]", i))
            });
        }
    }
