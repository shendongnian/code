    public async Task<IActionResult> OnPostExportByInMemoryAsync(string currentFilter)
    {
        string sFileName = @"PartCommentHistory.xlsx";
        using (var pck = new ExcelPackage())
        {
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Worksheet1");
            ws.Cells[1, 1].Value = "SupplierNo";
            ws.Cells[1, 2].Value = "PartNo";
            ws.Cells[1, 3].Value = "Comment";
            ws.Cells[1, 4].Value = "EnterBy";
            ws.Cells[1, 5].Value = "EnterDt";
            ws.Cells[1, 6].Value = "CompleteDt";
            ws.Cells["A:AZ"].AutoFitColumns();
            return File(pck.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
