    private void button1_Click(object sender, EventArgs e)
    {
        object Nothing = System.Reflection.Missing.Value;
        var app = new Microsoft.Office.Interop.Excel.Application();
        app.Visible = false;
        Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Add(Nothing);
        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];
        worksheet.Name = "WorkSheet";
        // Write data
        worksheet.Cells[1, 1] = "FileName";
        worksheet.Cells[1, 2] = "FindString";
        worksheet.Cells[1, 3] = "ReplaceString";
        // Show save file dialog
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            worksheet.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }
    }
