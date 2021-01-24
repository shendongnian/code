    decimal sum = 0.0m;
    for (int i = 0; i <GridView1.Rows.Count; ++i)
    {
        sum += Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
    }
