    int iCellCount = 3;  // In this example, i am defining cell count = 3 as static value. In the real time, cell count is picked from the excel file.
    var cellValue = string.Empty;
    DataTable dt = new DataTable();
    DataRow row;  //Create a DataRow
    foreach (ExcelReportCell excelCell in excelRow) // Iterating the excel cell row by row in the Excel Sheet
    {
                        cellValue = excelCell.GetText().ToString(); // cellValue is assigned dynamically through excel file cell by cell iteration logic
                        for (int i = 1; i <= iCellCount; i++)
                        {
                            row = dt.NewRow();
                            row["Your_Column_Name_Here"] = cellValue;
                            dt.Rows.Add(row);
                         }
    }
