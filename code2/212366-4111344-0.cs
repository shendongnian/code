    var data = new int[4,3]
    {
        { 1, 2, 3, },
        { 4, 5, 6, },
        { 7, 8, 9, },
        { 10, 11, 12 },
    };
    var rowCount = data.GetLength(0);
    var rowLength = data.GetLength(1);
    foreach (int rowIndex in Enumerable.Range(0, rowCount))
    {
        dataGridView1.Rows.Add(
            data.OfType<object>()
                .Skip(rowIndex * rowLength)
                .Take(rowLength)
                .ToArray()
            );
    }
