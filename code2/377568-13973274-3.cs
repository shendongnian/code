    public static class My_DataTable_Extensions
    {
    
    	// Export DataTable into an excel file with field names in the header line
    	// - Save excel file without ever making it visible if filepath is given
    	// - Don't save excel file, just make it visible if no filepath is given
        public static void ExportToExcel(this DataTable tbl, string excelFilePath = null) {
            try {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");
                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;
                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++) {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }
                // rows
                for (var i = 0; i < tbl.Rows.Count; i++) {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++) {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }
                // check file path
                if (!string.IsNullOrEmpty(excelFilePath)) {
                    try {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex) {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                } else { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex) {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
