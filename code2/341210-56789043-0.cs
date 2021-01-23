     public static class TableExtensions
    {
        public static void ShowOrHideColumn(this Table table, int index, bool bShowColumn)
        {
            foreach (TableRow row in table.Rows)
            {
                var colIndex = 0;
                var actionCol = 0;
                foreach (TableCell cell in row.Cells)
                {
                    if (colIndex == index)
                    {
                        row.Cells[actionCol].Visible = bShowColumn;
                        break;
                    }
                    colIndex += cell.ColumnSpan == 0 ? 1 : cell.ColumnSpan;
                    actionCol++;
                }
            }
        }
        public static void ShowOrHideColumn(this Table table, string id, bool bShowColumn)
        {
            int index = 0;
            bool columnFound = false;
            if (table.Rows.Count > 1)
            {
                TableHeaderRow headerRow = table.Rows[0] as TableHeaderRow;
                if (headerRow != null)
                {
                    foreach (TableHeaderCell cell in headerRow.Cells)
                    {
                        if (cell.ID != null && cell.ID.ToLower() == id.ToLower())
                        {
                            cell.Visible = bShowColumn;
                            columnFound = true;
                            break;
                        }
                        index += cell.ColumnSpan == 0 ? 1 : cell.ColumnSpan;
                    }
                }
            }
            if (columnFound)
                table.ShowOrHideColumn(index, bShowColumn);
        }
    }
