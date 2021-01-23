    using Microsoft.Office.Interop.Excel;
    using Sd = System.Data;
    private void FillTableData(ComObjectManager com, Sd.DataTable table, Worksheet worksheet, Range cells)
    {
        var firstCell = GetFirstCell(com, cells);
        var beginCell = com.Get<Range>(() => (Range)cells.Item[2, 1]);
        var endCell = GetLastContiguousCell(com, cells, firstCell);
        if (beginCell.Value == null) return;
        var range = GetRange(com, cells, beginCell, endCell);
        var data = (object[,])range.Value;
        var rowCount = data.GetLength(0);
        for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            var values = new object[table.Columns.Count];
            for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
            {
                var value = data[rowIndex + 1, columnIndex + 1];
                if (_valueAdjuster != null) value = _valueAdjuster(value);
                values[columnIndex] = value;
            }
            table.Rows.Add(values);
        }
    }
