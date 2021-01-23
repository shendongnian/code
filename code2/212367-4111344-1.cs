    var data = new int[4,3]
    {
        { 1, 2, 3, },
        { 4, 5, 6, },
        { 7, 8, 9, },
        { 10, 11, 12 },
    };
    var rowCount = data.GetLength(0);
    var rowLength = data.GetLength(1);
    for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
    {
        var row = new DataGridViewRow();
        for(int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
        {
            row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = data[rowIndex, columnIndex]
                });
        }
        dataGridView1.Rows.Add(row);
    }
