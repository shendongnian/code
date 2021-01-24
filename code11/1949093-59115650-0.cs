      Form2 fr = new Form2();
      private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        int row = DataGridView1.CurrentRow.Index;
        fr.Textbox1.Text = Convert.ToString(DataGridView1[0, row].Value);
        fr.Textbox2.Text = Convert.ToString(DataGridView1[1, row].Value);    
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        fr.ShowDialog();  
    }
