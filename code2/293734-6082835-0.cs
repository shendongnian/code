    private void button2_Click(object sender, EventArgs e)
    {
         StringBuilder builder = new StringBuilder();
         dataGirdView1.Rows.Cast<DataGridViewRow>().ToList()
             .ForEach(r => builder.Append(r.Cells[2].Value));
         textBox1.Text = builder.ToString();
    }
 
