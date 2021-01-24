    List<DataGridViewColumn> selectedcolumns = new List<DataGridViewColumn>();
    private void button1_Click(object sender, EventArgs e)
    {
        bool flag = true;
        selectedcolumns.Clear();
        foreach (DataGridViewColumn column in dataGridView1.Columns)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[column.Index].Selected == false)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                selectedcolumns.Add(column);
            flag = true;
        }
        foreach (DataGridViewColumn c in selectedcolumns)
            Console.WriteLine(c.Index);
    }
