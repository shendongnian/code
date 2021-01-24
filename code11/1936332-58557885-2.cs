    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var bc = BindingContext[dataGridView1.DataSource];
        bc.SuspendBinding();
        for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
        {
            dataGridView1.Rows[i].Visible = (dataGridView1.Rows[i].Cells[3].Value.ToString() == comboBox1.Text);
        }
        bc.ResumeBinding();
    }        
 
            
