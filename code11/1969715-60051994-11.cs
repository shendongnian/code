    private void btnAddItem_Click(object sender, EventArgs e) {
       if (!AllFieldsEntered()) {
        MessageBox.Show("'ID', 'Type','Name', 'Expense' and 'Income' fields cannot be empty!");
      }
      else {
        StringBuilder errorString = new StringBuilder("Invalid Values: " + Environment.NewLine);
        bool noErrors = true;
        if (!int.TryParse(txtID.Text, out int id)) {
          errorString.AppendLine("ID must be a valid integer");
          noErrors = false;
        }
        if (!decimal.TryParse(expenseField.Text, out decimal exp)) {
          errorString.AppendLine("Expense must be a valid decimal");
          noErrors = false;
        }
        if (!decimal.TryParse(incomeField.Text, out decimal inc)) {
          errorString.AppendLine("Income must be a valid decimal");
          noErrors = false;
        }
        if (noErrors) {
          BudgetList.Add(new BudgetItem(id, dtpDate.Value, cbbxType.Text, nameField.Text, exp, inc));
          DtgTable.DataSource = null;
          DtgTable.DataSource = BudgetList;
        }
        else {
          MessageBox.Show(errorString.ToString());
        }
      }
    }
