    int _index = 0;
    int fixedWidth = 200;
    private void button1_Click(object sender, EventArgs e)
    {
    
                var col = new DataGridViewColumn();
                col.Name = $"Col{_index++}";
                col.Width = fixedWidth;
                col.CellTemplate = new DataGridViewTextBoxCell();
                dataGrid.Columns.Add(col);
     }
