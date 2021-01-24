            private void dataGridViewReader_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {             
    
                string columnName = dataGridViewReader.CurrentCell.OwningColumn.Name;
                string columnName2 = dataGridViewReader.CurrentCell.Value.ToString();
    
                if (columnName2 == "Notes")
                {
                    for (int rows = 1; rows < dataGridViewReader.Rows.Count; rows++)
                    {
                        if (!string.IsNullOrEmpty(dataGridViewReader.Rows[rows].Cells[dataGridViewReader.CurrentCell.ColumnIndex].Value.ToString()))
                        {
                            dataGridViewReader.Rows[rows].Cells[0].Value += dataGridViewReader.Rows[rows].Cells[dataGridViewReader.CurrentCell.ColumnIndex].Value + @"<br/>";
                        }
    
                    }
                }
    
     
                DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGridViewReader.Rows[0].Cells[dataGridViewReader.CurrentCell.ColumnIndex];
                dgvcbc.Style.ForeColor = Color.DarkGreen;
    
            }
