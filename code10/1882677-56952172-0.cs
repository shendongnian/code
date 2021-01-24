            var sheetData = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
            sheetData.Name = "Data";
            object[,] arr = new object[dataTable.Rows.Count + 1, dataTable.Columns.Count];
            for (int c = 0; c < dataTable.Columns.Count; c++)
            {
                arr[0, c] = dataTable.Columns[c].ColumnName;
            }
            int arrRow = 1;
            for (int r = 0; r < dataTable.Rows.Count; r++)
            {
                DataRow dr = dataTable.Rows[r];
                for (int c = 0; c < dataTable.Columns.Count; c++)
                {
                    arr[arrRow, c] = dr[c];
                }
                ++arrRow;
            }
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)sheetData.Cells[1, 1];
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)sheetData.Cells[2 + dataTable.Rows.Count - 1, dataTable.Columns.Count];
            Microsoft.Office.Interop.Excel.Range range = sheetData.get_Range(c1, c2);
            range.Value = arr;
