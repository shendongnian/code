    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int cellmarks = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (cellmarks < 32)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Fail";
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Pass";
                    }
    
                }
            }
