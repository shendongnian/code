    // Unhide All Cells
    sheet.UsedRange.EntireRow.Hidden = false;
    sheet.UsedRange.EntireColumn.Hidden = false;
    // Detect Last used Row
    int lastRow = sheet.Cells.Find(
                    "*",
                    System.Reflection.Missing.Value,
                    InteropExcel.XlFindLookIn.xlValues,
                    InteropExcel.XlLookAt.xlWhole,
                    InteropExcel.XlSearchOrder.xlByRows,
                    InteropExcel.XlSearchDirection.xlPrevious,
                    false,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value).Row;
    // Detect Last Used Column
    int lastCol = sheet.Cells.Find(
                    "*",
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value,
                    InteropExcel.XlSearchOrder.xlByColumns,
                    InteropExcel.XlSearchDirection.xlPrevious,
                    false,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value).Column;
