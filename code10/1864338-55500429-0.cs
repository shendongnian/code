     foreach (DataGridViewRow row in dataGridView5.Rows)
                {
    
                   if (row.Cells["PG RANK"] == row.Cells["PG RANK"] && row.Cells["Teams"].Value.Equals(row.Cells["Teams"].Value))
                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            if (row2.Cells["Against"].Value.Equals(row.Cells["Teams"].Value) && row2.Cells["Position"].Value.Equals("PG"))
                                {
                                row2.Cells["OppAgainstRank"].Value = row.Cells["PG RANK"].Value;
                               
                            }
    
                        }
                    
                }
    
    
    
    
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
    
                    if (row.Cells["SG RANK"] == row.Cells["SG RANK"] && row.Cells["Teams"].Value.Equals(row.Cells["Teams"].Value))
                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            if (row2.Cells["Against"].Value.Equals(row.Cells["Teams"].Value) && row2.Cells["Position"].Value.Equals("SG"))
                            {
                                row2.Cells["OppAgainstRank"].Value = row.Cells["SG RANK"].Value;
    
                            }
    
                        }
    
                }
    
    
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
    
                    if (row.Cells["SF RANK"] == row.Cells["SF RANK"] && row.Cells["Teams"].Value.Equals(row.Cells["Teams"].Value))
                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            if (row2.Cells["Against"].Value.Equals(row.Cells["Teams"].Value) && row2.Cells["Position"].Value.Equals("SF"))
                            {
                                row2.Cells["OppAgainstRank"].Value = row.Cells["SF RANK"].Value;
    
                            }
    
                        }
    
                }
    
    
    
    
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
    
                    if (row.Cells["PF RANK"] == row.Cells["PF RANK"] && row.Cells["Teams"].Value.Equals(row.Cells["Teams"].Value))
                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            if (row2.Cells["Against"].Value.Equals(row.Cells["Teams"].Value) && row2.Cells["Position"].Value.Equals("PF"))
                            {
                                row2.Cells["OppAgainstRank"].Value = row.Cells["PF RANK"].Value;
    
                            }
    
                        }
    
                }
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
    
                    if (row.Cells["C RANK"] == row.Cells["C RANK"] && row.Cells["Teams"].Value.Equals(row.Cells["Teams"].Value))
                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            if (row2.Cells["Against"].Value.Equals(row.Cells["Teams"].Value) && row2.Cells["Position"].Value.Equals("C"))
                            {
                                row2.Cells["OppAgainstRank"].Value = row.Cells["C RANK"].Value;
    
                            }
    
                        }
    
                }
