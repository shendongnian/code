    GridEXRow FRow = grdTest.FilterRow;
    if (FRow != null)
    {
      grdTest.Row = FRow.RowIndex;
      grdTest.Col = grdTest.RootTable.Columns["ColumnName"].Index
    }
