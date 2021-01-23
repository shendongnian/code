    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter) 
            {
                    bindingsource2.ResumeBinding (); // OR bindingsource2.SuspendBinding();       
                    int i = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1[1, i].Value = textBox1.Text;
                    dataGridView1.Focus();
            }
            
        }
