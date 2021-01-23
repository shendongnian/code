    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        // Test if the first column of the current row equals
        // the value in the text box
        if ((string)row.Cells[0].Value == textBox1.Text)
        {
            // we have a match
            row.Selected = true;
        }
        else
        {
            row.Selected = false;
        }
    }
