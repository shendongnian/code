    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
    {
        (worksheet.Rows[i+2 + ":" + i+2, System.Reflection.Missing.Value] as Excel.Range).NumberFormat = "@";
        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        {
            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
        }
    }
