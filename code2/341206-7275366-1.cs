    tbl.HideColumn("HeaderID");
    tbl.HideColumn(0);
    ....
    public static class TableExtensions
    {
        public static void HideColumn(this Table table, int index)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row.Cells.Count-1 >= index)
                {
                    row.Cells[index].Visible = false;
                }
            }
        }
        public static void HideColumn(this Table table, string id)
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
                        if (cell.ID.ToLower() == id.ToLower())
                        {
                            columnFound = true;
                            break;
                        }
                        index++;
                    }
                }
            }
            if(columnFound)
                HideColumn(table, index);
        }
    }
