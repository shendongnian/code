            // Filename
            string filename = "...";
            Label lbl_filename = new Label();
            lbl_filename.Text = filename;
            // ...
            // Button
            LinkButton button = new LinkButton();
            button.Text = "Download";
            // ...
            GridViewRow row = new GridViewRow(i, i, DataControlRowType.DataRow, DataControlRowState.Normal);
            TableCell cell = new TableCell();
            cell.ColumnSpan = some_columnspan;
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.Controls.Add(lbl_filename); // add control
            cell.Controls.Add(button); // add control
            row.Cells.Add(cell);
