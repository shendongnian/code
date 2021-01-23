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
    }
