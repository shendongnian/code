    // default cell style will set all cells (including corner) on the top header "row"
    dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
    
    // explicitly set all of the normal column headers back to the desired style
    foreach(DataGridViewColumn item in dgview.Columns)
    {
         item.HeaderCell.Style.BackColor = SystemColors.ButtonFace;
    }
