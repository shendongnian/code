    for (int i = 0; i < DataGridView1.Rows.Count; i++)
         {
           double val1, val2;
           double.TryParse(Txtmonth.Text, out val1);
           DataGridView1.Rows[i].Cells[10].Value = Convert.ToDouble(DataGridView1.Rows[i].Cells[10].Value) * val1;
         }
