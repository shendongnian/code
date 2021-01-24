    int col1Count = 0;
    int col2Count = 0;
    int col3Count = 0;
    bool cellValue;
    foreach ( DataGridViewRow row in gridView.Rows )
    {
        cellValue = (bool) row.Cells["col1"].Value;
        if ( cellValue )
        {
            ++col1Count;
        }
        cellValue = (bool) row.Cells["col2"].Value;
        if ( cellValue )
        {
            ++col2Count;
        }
        cellValue = (bool) row.Cells["col3"].Value;
        if ( cellValue )
        {
            ++col3Count;
        }
    }
