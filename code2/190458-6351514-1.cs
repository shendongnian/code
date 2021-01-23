    using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo("testReport.xlsx")))
    {
      ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("worksheet");
      ws.Cells[1, 1, 3, 1].Value = 0d;
      ws.Cells[1, 2, 3, 2].Value = -14.957d;
      ws.Cells[1, 3, 3, 3].Value = 5000000.00d;
      ws.Cells[1, 4, 3, 4].Value = -50000000000.00d;
      ws.Cells[1, 1, 1, 4].Style.Numberformat.Format = "#,##0.00;(#,##0.00)";
      ws.Cells[2, 1, 2, 4].Style.Numberformat.Format = "#,##0.00;-#,##0.00";
      ws.Cells[3, 1, 3, 4].Style.Numberformat.Format = "\"$\"#,##0.00;[Red]\"$\"#,##0.00";
      ws.Cells[1, 1, 3, 4].AutoFitColumns();
      excelPackage.Save();
    }
