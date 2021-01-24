    private DataRowView rowBeingEdited = null;
    
    private void dataGrid_CellEditEnding(object sender,
                                      DataGridCellEditEndingEventArgs e)
    {
        DataRowView rowView = e.Row.Item as DataRowView;
        rowBeingEdited = rowView;
    }
    
    private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
    {
        if (rowBeingEdited != null)
        {
            rowBeingEdited.EndEdit();
        }
    }
