    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex > 0)
                {
                    MessageBox.Show("Clicked cell");
                }
    
                else if (e.RowIndex < 0)
                {
                    MessageBox.Show(" header Clicked'");
                    
                }
            }
