     if (e.ColumnIndex == 0) //delete button has been clicked
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
    
                        if (dataGridViewRow.Cells.Count > 1)
                        {
                            DeleteClient(dataGridViewRow.Cells[e.ColumnIndex + 1].FormattedValue.ToString());
                        }
                    }
                    else
                    {
                        LogToFile(e.RowIndex.ToString());
                    }
                }
