    private void buttonRemoveSelected_Click(object sender, EventArgs e)
    {
        string item = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        if (item != null)
        {
            int _id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            foreach (Person p in bList)
            {
                if (p.id == _id)
                    p.name = "";
            }
        }
    }
