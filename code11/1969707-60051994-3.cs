    private void FillListFromCSV(string file) {
      BudgetList = new BindingList<BudgetItem>();
      StreamReader sr = new StreamReader(file);
      string curLine = sr.ReadLine(); // <- ignore header row
      if (curLine != null) {
        BudgetItem BI;
        while ((curLine = sr.ReadLine()) != null) {
          if ((BI = GetBudgetItemFromString(curLine)) != null) {
            BudgetList.Add(BI);
          }
          else {
            MessageBox.Show("Error invalid Budget Item: " + curLine);
          }
        }
      }
      sr.Close();
    }
