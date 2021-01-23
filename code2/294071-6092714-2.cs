    using Microsoft.Office.Interop.Excel;
    using Sd = System.Data;
    private void FillTableData(Sd.DataTable table, Worksheet worksheet, Range cells)
    {
        using (var com = new ComObjectManager())
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
                    values[columnIndex] = value;
                }
                table.Rows.Add(values);
            }
        }
    }
    private Range GetFirstCell(ComObjectManager com, Range cells)
    {
        return com.Get<Range>(() => (Range)cells.Item[1, 1]);
    }
    private Range GetLastContiguousCell(ComObjectManager com, Range cells, Range beginCell)
    {
        var bottomCell = com.Get<Range>(() => beginCell.End[XlDirection.xlDown]);
        var rightCell = com.Get<Range>(() => beginCell.End[XlDirection.xlToRight]);
        return com.Get<Range>(() => (Range)cells.Item[bottomCell.Row, rightCell.Column]);
    }
