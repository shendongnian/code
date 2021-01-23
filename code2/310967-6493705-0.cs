    TableCell tc = new TableCell();
    Label label = new Label();
    label.Text = reader.GetString(col);
    // Add the control to the TableCell
    tc.Controls.Add(label);
    // Add the TableCell to the TableRow
    tr.Cells.Add(tc);
    col++;
