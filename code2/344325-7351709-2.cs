    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in e.Layout.Bands[0].Columns)
    {
        if(NamesEqual(column.Key, "ID"))
        {
            column.Header.Caption = "MyNewColumnName";
        }
    }
