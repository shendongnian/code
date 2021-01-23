    var daysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);
    
    for (int i = 1; i <= daysCount; i++)
    {
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = i.ToString() });
    }
