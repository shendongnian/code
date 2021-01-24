        ..
        myDataGridView.CellFormatting += myDataGridView_CellFormatting;
        ..
        
        private void myDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            // First ill check if im in right column
            // Second if checks if the value starts with "Date"
            if (e.ColumnIndex == myDataGridView.Columns("columnName").Index) {
                if (myDataGridView.Rows(e.RowIndex).Cells("columnName").Value.ToString().StartsWith("Date") {
                     // apply your formatting
                     myDataGridView.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Underline);
                }
            }
        }
