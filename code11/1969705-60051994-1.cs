    private void FillDataTableFromCSV(string file) {
      StreamReader sr = new StreamReader(file);
      string[] splitArray;
      int maxColumns = BudgetTable.Columns.Count - 1; // <- the last column is a computed column we dont want to save
      int curColCount = maxColumns;
      string curLine = sr.ReadLine();
      if (curLine != null) {
        DataRow newRow;
        while ((curLine = sr.ReadLine()) != null) {
          splitArray = curLine.Split('\t');
          curColCount = maxColumns;
          if (splitArray.Length < maxColumns) {
            curColCount = splitArray.Length;
          }
          newRow = BudgetTable.Rows.Add();
          for (int i = 0; i < curColCount; i++) {
            newRow[i] = splitArray[i];
          }
        }
      }
      sr.Close();
    }
