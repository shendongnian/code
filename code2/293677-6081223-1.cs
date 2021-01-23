    private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    Form1 frm = new Form1(DataGridView1.CurrentRow.Cells["ID"].Value.ToString())); 
                    frm .ShowDialog();
                   
                }
                catch (Exception ex)
                {
                }
    
            }
