        /// <summary>
        /// Converts a Worksheet to a DataTable
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        private static DataTable WorksheetToDataTable(ExcelWorksheet worksheet)
        {
            // Vars
            var dt = new DataTable();
            var rowCnt = worksheet.Dimension.End.Row;
            var colCnt = worksheet.Dimension.End.Column + 1;
            // Loop through Columns
            for (var c = 1; c < colCnt; c++ )
            {
                // Add Column
                dt.Columns.Add(new DataColumn());
                // Loop through Rows
                for(var r = 1; r < rowCnt; r++ )
                {
                    // Add Row
                    if (dt.Rows.Count < (rowCnt-1)) dt.Rows.Add(dt.NewRow());
                    // Populate Row
                    dt.Rows[r - 1][c - 1] = GetValue(worksheet.Cells[r, c]);
                }
            }
            // Return
            return dt;
        }
