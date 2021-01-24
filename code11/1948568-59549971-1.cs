    private void button1_Click(object sender, EventArgs e) {
      StreamWriter outputCSV = new StreamWriter(@"D:\Test\Excel_Test\export.csv", true);
      DirectoryInfo folder = new DirectoryInfo(@"D:\Test\Excel_Test\");
      FileInfo[] files = folder.GetFiles("*.xlsx");
      int count = 1;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      foreach (var file in files) {
        //ExtractData(file, outputCSV);
        ExtractData3(file, outputCSV);
        count++;
      }
      MessageBox.Show("Done! It took: " + sw.ElapsedMilliseconds + " milliseconds");
      outputCSV.Close();
    }
    private void ExtractData3(FileInfo filename, StreamWriter output) {
      Excel.Application xlApp = new Excel.Application();
      Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filename.FullName);
      Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
      Object[,] dataArray = (Object[,])xlWorksheet.UsedRange.Cells.Value2;
      string fileDate = filename.Name.Substring(0, 7);
      if (filename.Name.Contains("WIP")) {
        //EXTRACT MMT
        fileDate = fileDate + ",";
      }
      else {
        //EXTRACT AMKOR
        fileDate = fileDate + ",,,,,,,,,,,";
      }
      WriteData(dataArray, fileDate, output);
      Marshal.ReleaseComObject(xlWorksheet);
      xlWorkbook.Close();
      Marshal.ReleaseComObject(xlWorkbook);
      xlApp.Quit();
      Marshal.ReleaseComObject(xlApp);
    }
    private void WriteData(Object[,] dataArray, string prefix, StreamWriter output) {
      int rowCount = dataArray.GetLength(0);
      int colCount = dataArray.GetLength(1);
      StringBuilder sb = new StringBuilder();
      sb.Append(prefix + ",");
      for (int i = 1; i <= rowCount; i++) {
        for (int j = 1; j <= colCount; j++) {
          if (dataArray[i, j] != null) {
            sb.Append(dataArray[i, j]);
            if (j < colCount) {
              sb.Append(",");
            }
          }
          else {
            sb.Append(",");
          }
        }
        output.WriteLine(sb.ToString());
        sb.Clear();
        sb.Append(prefix + ",");
      }
    }
     
