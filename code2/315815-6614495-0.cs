    private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
        // As an example we'll check contents of column index 1 in our DGV.
        string numberString = dataGridView1.Rows[e.RowIndex].Cells[1].Value as string;
        if (numberString != null) {
            int number;
            if (Int32.TryParse(numberString, out number)) {
                if (number > 10) {
                    // Display one icon.
                } else {
                    // Display the other icon.
                }
            } else {
                // Do something because the string that is in the cell cannot be converted to an int.
            }
        } else {
            // Do something because the cell Value cannot be converted to a string.
        }
    }
