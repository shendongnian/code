    private void dataGridView1_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            string headerText = 
                dataGridView1.Columns[e.ColumnIndex].HeaderText;
            // Abort validation if cell is not in the Age column.
            if (!headerText.Equals("Age")) return;
            int output;
            // Confirm that the cell is an integer.
            if (!int.TryParse(e.FormattedValue.ToString(), out output))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Age must be numeric";
                e.Cancel = true;
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }
