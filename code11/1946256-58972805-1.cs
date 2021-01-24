    private void YourForm_Load(object sender, EventArgs e)
    {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["selected"];
                if(something)
                {
                    chk.Value = true;
                }
                else
                {
                    chk.Value = false;
                }
            }
    }
