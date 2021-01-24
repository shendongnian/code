    private void button1_Click(object sender, EventArgs e) {
      //SaveFileDialog saveFileD = new SaveFileDialog();
      //string fileName = truckListBox.SelectedItem.ToString() + "__" + DateTime.Now.ToShortDateString();
      string fileName = @"C:\Users\John\Desktop\Grr\TestExcelFile" + "__" + DateTime.Now.Year + "_" + DateTime.Now.Month;
      //saveFileD.InitialDirectory = @"C:\Users\John\Desktop\Grr\";
      //saveFileD.FileName = fileName;
      //if (!Directory.Exists(@"C:/TML/"))
      //    Directory.CreateDirectory(@"C:/TML/");
      //List<DataGridView> dataGridViews = getAllDataGridViews();
      List<DataGridView> dataGridViews = getGrids();
      Microsoft.Office.Interop.Excel.Application app = null;
      Microsoft.Office.Interop.Excel.Workbook book = null;
      Microsoft.Office.Interop.Excel.Worksheet sheet = null;
      app = new Microsoft.Office.Interop.Excel.Application();
      app.Visible = true;
      book = app.Workbooks.Add(System.Reflection.Missing.Value);
      try {
        foreach (var grid in dataGridViews) {
          int count = book.Worksheets.Count;
          //sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets.Add(Type.Missing, book.Worksheets[count], Type.Missing, Type.Missing);
          sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets.Add();
          //sheet.Name = grid.Name.ToString().Remove(0, 13);
          sheet.Name = grid.Name.ToString();
          int cMin = 1, rMin = 1;
          int c = cMin, r = rMin;
          // Set Headers
          foreach (DataGridViewColumn column in grid.Columns) {
            //Here appears the Error: System.Runtime.InteropServices.COMException: HRESULT: 0x800A03EC"
            sheet.Cells[r, c] = column.HeaderText;
            c++;
          }
          sheet.Range[sheet.Cells[r, cMin], sheet.Cells[r, c]].Font.Bold = true;
          sheet.Range[sheet.Cells[r, cMin], sheet.Cells[r, c]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
          // Set Rows
          foreach (DataGridViewRow row in grid.Rows) {
            r++;
            c = cMin;
            // Set Cells
            foreach (DataGridViewCell item in row.Cells) {
              sheet.Cells[r, c++] = item.Value;
            }
          }
        }
        book.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing);
        book.Close();
        app.Quit();
      }
      catch (Exception ex) {
        MessageBox.Show("Error writing to excel: " + ex.Message);
      }
      finally {
        if (sheet != null)
          Marshal.ReleaseComObject(sheet);
        if (book != null)
          Marshal.ReleaseComObject(book);
        if (app != null)
          Marshal.ReleaseComObject(app);
      }
    }
