    private DataTable ReadExcelFile(string flatFilePath, bool firstRowHasHeaders)
        {
            SpreadsheetInfo.SetLicense("MY KEY");
            ExcelFile excelFile = new ExcelFile();
            excelFile.LoadXls(flatFilePath);
            int unnamed = 0;
            int cols;
            string[] columns;
            int curRow = 0;
            int curCol = 0;
            DataTable dataTable = new DataTable();
            ExcelWorksheet worksheet = excelFile.Worksheets[0];
            for (cols = 0; cols < worksheet.Rows[0].AllocatedCells.Count; cols++)
            {
                if (firstRowHasHeaders)
                {
                    if (worksheet.Rows[0].Cells[cols].Value != null)
                        dataTable.Columns.Add(worksheet.Rows[0].Cells[cols].Value.ToString());
                    else
                    {
                        dataTable.Columns.Add("Unnamed Column " + (++unnamed));
                    }
                    curRow = 1;
                }
                else
                {
                    dataTable.Columns.Add("Column " + (cols + 1));
                }
            }
            for (; curRow < worksheet.Rows.Count; curRow++)
            {
                columns = new string[cols];
                for (curCol = 0; curCol < cols; curCol++)
                {
                    if (worksheet.Rows[curRow].Cells[curCol].Value == null)
                        columns[curCol] = "";
                    else
                        columns[curCol] = worksheet.Rows[curRow].Cells[curCol].Value.ToString();
                }
                dataTable.Rows.Add(columns);
            }
            return dataTable;
        }
