    if(!Convert.IsDbNull(dataGridView1.Rows[0].Cells[i].Value))
    {
        if (i != 0)
        {
           ar[i] = dataGridView1.Rows[0].Cells[i].Value.ToString ();
        }
        else
        {
           ar[i] = dataGridView1.Rows[0].Cells[i].Value.ToString();
        }
    }
