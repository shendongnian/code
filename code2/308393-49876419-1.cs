    foreach (DataGridViewRow row in dataGridView1.Rows.Cast<DataGridViewRow>().Skip(3))
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            string value = cell.Value.ToString();
            dataGridView2.Rows[i].Cells[j].Value = cell.Value.ToString();
            j++;
        }
        i++;
        j = 0;
    }
