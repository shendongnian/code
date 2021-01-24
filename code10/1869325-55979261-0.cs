    DateTime startTime = DateTime.Now;
    DateTime finishTime = DateTime.Now;
    int columns = 442;
    int rows = 181872;
    DataTable dt = new DataTable();
    string[] values = new string[columns];
    for (int i = 0; i < columns; i++)
    {
        values[i] = "test" + i;
        dt.Columns.Add(values[i]);
    }
    for (int row = 0; row < rows; row++)
    {
        DataRow dataRow = dt.NewRow();
        dt.Rows.Add(dataRow);
        for (int col = 0; col < columns; col++)
        {
            dataRow[col] = values[col];
        }
    }
    finishTime = DateTime.Now;
    Console.WriteLine("load Excel worksheet data into Data table: (Aspose) " + (finishTime - startTime));
