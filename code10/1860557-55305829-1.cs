     StringBuilder rows = new StringBuilder();
     var row = string.Empty;
     for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
     {
        row = string.Join(",", dataGridView1.Rows[i].Cells.Cast<DataGridViewCell>().Select(x => x.Value));
        int.TryParse(dataGridView1.Rows[i].Cells["Quantity"].Value?.ToString(), out var quantity);
        for (int q = 0; q < quantity; q++)
        {
           rows.AppendLine(row);
        }      
     }
     var strValue = rows.ToString();
