    private void SetTableColumns() {
      BudgetTable = new DataTable();
      BudgetTable.Columns.Add("Id", typeof(Int32));
      BudgetTable.Columns.Add("Date", typeof(DateTime));
      BudgetTable.Columns.Add("Type", typeof(String));
      BudgetTable.Columns.Add("Name", typeof(String));
      BudgetTable.Columns.Add("Expenses", typeof(decimal));
      BudgetTable.Columns.Add("Income", typeof(decimal));
      BudgetTable.Columns.Add("Balance", typeof(decimal));
      BudgetTable.Columns["Balance"].Expression = "Income - Expenses";
    }
