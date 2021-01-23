     void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
     {
         dataGridView1.Rows[e.RowIndex].ReadOnly = checkrow(dataGridView1.Rows[e.RowIndex]);
     }
 
     bool checkrow(DataGridViewRow testrow)
     {
            for (int i = 0; i < testrow.Cells.Count; i++)
            {
                if (testrow.Cells[i].Value != null)
                {
                    // if datagridview is databound, you'd better check whether the cell value is string.Empty
                    if (testrow.Cells[i].Value.ToString() != string.Empty)
                    {
                        // if value of any cell is not null, this row need to be readonly
                        return true;
                    }
 
                    // if there is an unbound checkbox column, you may need to check whether the cell value is null or false(uncheck).
                }
            }
 
            // else false
            return false;
     }
