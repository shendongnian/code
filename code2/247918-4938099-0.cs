    UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
    
    // Sort the rows by Country and City fields. Notice the order in which these columns
    // are set. We want to sort by Country and then sort by City and in order to do that
    // we have to set the SortIndicator property in the right order.
    band.Columns["Country"].SortIndicator = SortIndicator.Ascending;
    band.Columns["City"].SortIndicator    = SortIndicator.Ascending;
    
    // You can also sort (as well as group rows by) columns by using SortedColumns
    // property off the band.
    band.SortedColumns.Add( "ContactName", false, false );
