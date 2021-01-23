           if (dtbl.Rows.Count > 0)
            {
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                        // adding a row each time it loops in and find a row in the dtbl
                        dataGridView1.Rows.Add();
                    
                        dataGridView1.Rows[i].Cells[0].Value = dtbl.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dtbl.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dtbl.Rows[i][2].ToString();
                }
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }  
