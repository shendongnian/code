    foreach (DataGridViewRow i in dataGridView1.Rows)
    {
       if(i.Cells[1].Value == null){ }
       else{
        name.Add(i.Cells[1].Value.ToString());
        }
    }
