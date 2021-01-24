    private void updateWidth()
            {
                foreach (DataGridViewColumn item in dataGrid.Columns)
                {
                    item.Width = dataGrid.Columns.Count == 0 ?
                                    dataGrid.Width
                                    : (int)(dataGrid.Width / dataGrid.Columns.Count);
                }
            }
    int _index = 0;
    private void button1_Click(object sender, EventArgs e){
    
                var col = new DataGridViewColumn();
                col.Name = $"Col{_index++}";
                col.CellTemplate = new DataGridViewTextBoxCell();
                dataGrid.Columns.Add(col);
                updateWidth();
            }
        }
