    saveFileDialog.InitialDirectory = "C:";
    saveFileDialog.Title = "Save as Excel File";
    saveFileDialog.FileName = "Data";
    saveFileDialog.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
    if (saveFileDialog.ShowDialog() != DialogResult.Cancel) {
      Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
      Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Application.Workbooks.Add(Type.Missing);
      Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
      excelApp.Columns.ColumnWidth = 20;
      for (int i = 1; i < dgwReport.Columns.Count + 1; i++) {
        worksheet.Cells[1, i] = dgwReport.Columns[i - 1].HeaderText;
      }
      for (int i = 0; i < dgwReport.Rows.Count; i++) {
        for (int j = 0; j < dgwReport.Columns.Count; j++) {
          worksheet.Cells[i + 2, j + 1] = dgwReport.Rows[i].Cells[j].Value;
        }
      }
      excelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog.FileName.ToString());
      excelApp.ActiveWorkbook.Saved = true;
      workbook.Close();
      excelApp.Quit();
    }
