    tableLayoutPanel1.ColumnStyles.Clear();
    for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
    {
       tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
    }
    tableLayoutPanel1.RowStyles.Clear();
    for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
    {
       tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    }
