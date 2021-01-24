        private void CreateExcelFile(string sheet1Name, string sheet2Name)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.Filter = "(All files)|*.*|(Excel)|*.xlsx|(Excel 97-2003)|*.xls";
            save.FilterIndex = 2;
            save.ShowDialog();
            if (save.FileName != "")
            {
                try
                {
                    // Create an Excel App
                    Excel.Application app = new Excel.Application();
                    // Create a new Workbok                
                    Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                    // Creat a new WorkSheet
                    Excel.Worksheet ws = null;
                    app.Visible = false;
                    ws = wb.ActiveSheet;
                    // Name 1
                    ws.Name = sheet1Name;
                    // WorkSheet 2
                    Excel.Worksheet ws2 = wb.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                    // Name 2
                    ws2.Name = sheet2Name;
                    // Save
                    wb.SaveAs(save.FileName);
                    // Show the app
                    app.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
        }
