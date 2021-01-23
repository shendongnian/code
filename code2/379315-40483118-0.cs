    foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    IEnumerable<DataGridViewCell> cellsWithValusInRows = from DataGridViewCell cell in row.Cells
                                                                         where !string.IsNullOrEmpty((string)cell.Value)
                                                                         select cell;
                    if (cellsWithValusInRows != null && cellsWithValusInRows.Any())
                    {
                        //Then cells with null or empty values where found  
                    }
                }
    
