    private void dataGridView1_CellValidating(object sender,DataGridViewCellValidatingEventArgs e)
    {
       // Validate the CompanyName entry by disallowing empty strings.
        if (dataGridView1.Columns[e.ColumnIndex].Name == "CompanyName")
        {
            if (e.FormattedValue == null && String.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
              dataGridView1.Rows[e.RowIndex].ErrorText =
                "Company Name must not be empty";
               e.Cancel = true;
            }
       }
    }
    void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
         // Clear the row error in case the user presses ESC.   
          dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
    }
