    foreach (DataControlField field in _gridView.Columns)
    {
        TableCell cell = new TableCell();
        cell.Text = "&nbsp;";
        if (field.ItemStyle.CssClass == "hideGridColumn")
            cell.Visible = false;
        
        row.Cells.Add(cell);
    }
