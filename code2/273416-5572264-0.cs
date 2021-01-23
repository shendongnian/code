    void SetRange(Worksheet worksheet, DataSet dataSet)
    {
        object[] values = GetValuesFromDataSet(dataSet);
        int rowCount = values.GetUpperBound(0);
        int columnCount = values.GetUpperBound(1);
        Range range = worksheet.Range(worksheet.Cells(1, 1), worksheetCells.(rowCount, columnCount));
        range.Value = values;
    }
