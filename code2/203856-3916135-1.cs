    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {    
                foreach (DataGridViewRow gr in old)
                {
                    if (gr == dataGridView1.CurrentRow)
                    {
                        gr.Selected = false;
                    }
                    else
                    {
                        gr.Selected = true;
                    }    
                }  
            }
        
