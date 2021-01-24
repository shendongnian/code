    private IEnumerable<IEnumerable<DataGridViewRow>> SplitDataGridView(DataGridView dgv)
    {
        var rows = new List<DataGridViewRow>(size);
        
        foreach (DataGridViewRow row in dgv.Rows)
        {
            rows.Add(row);
            if (rows.Count == size)
            {
                yield return rows;
                rows = new List<DataGridViewRow>(size);
            }
        }
        if (rows.Count > 0)
        {
            yield return rows;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        foreach (var rows in SplitDataGridView(dataGridView))
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append(cell.Value);
                    sb.Append(delimiter);
                }
                sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString());
        }
    }
