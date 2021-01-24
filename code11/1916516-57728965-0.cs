            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(fileLocation, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            Excel.Range usedRange = worksheet.UsedRange;
            int rowCount = usedRange.Rows.Count;
            int colCount = usedRange.Columns.Count;
            for (int i = rowCount; i >= 1; i--)
            {
                if (string.IsNullOrEmpty((worksheet.Cells[i, 1]).Text.ToString()))
                {
                    // Delete entire row if first cell is empty
                    (worksheet.Cells[i, 1]).EntireRow.Delete();
                }
    }
            workbook.Save();
