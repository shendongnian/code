    saveFileDialog.InitialDirectory = "C:";
    saveFileDialog.Title = "Save as Excel File";
    saveFileDialog.FileName = "Data";
    saveFileDialog.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
    Microsoft.Office.Interop.Excel.Application excelApp = null;
    Microsoft.Office.Interop.Excel.Workbook workbook = null;
    Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
    try {
       if (saveFileDialog.ShowDialog() != DialogResult.Cancel) {
        excelApp = new Microsoft.Office.Interop.Excel.Application();
        workbook = excelApp.Application.Workbooks.Add(Type.Missing);
        worksheet = workbook.ActiveSheet;
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
    }
    catch (Exception ex) {
      MessageBox.Show("Excel write error: " + ex.Message);
    }
    finally {
      // release the excel objects to prevent leaking the unused resource
      if (worksheet != null)
        Marshal.ReleaseComObject(worksheet);
      if (workbook != null)
        Marshal.ReleaseComObject(workbook);
      if (excelApp != null)
        Marshal.ReleaseComObject(excelApp);
    }
