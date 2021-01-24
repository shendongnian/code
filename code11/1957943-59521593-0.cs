    private void dataGridView1_CellFormatting(object sender, 
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            // Format the string.
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Balance"))
            {
                // Ensure that the value is a string.
                String stringValue = e.Value as string;
                if (stringValue == null) return;
                e.Value = JToken.Parse(stringValue).ToString();
            }
        }
