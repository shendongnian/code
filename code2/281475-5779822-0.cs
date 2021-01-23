    UltraGridColumn ugc = myGrid.DisplayLayout.Bands[0].Columns[@"myColumnKey"];
    
    private void mygrid_CellChange(object sender, CellEventArgs e)
    {
        if (StringComparer.OrdinalIgnoreCase.Equals(e.Cell.Column.Key, @"myColumnKey"))
        {
             //something like this
             ugc [@"myColumnKey"][index];
        }
    }
