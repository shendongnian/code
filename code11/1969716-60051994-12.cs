    private bool AllFieldsEntered() {
      if (string.IsNullOrWhiteSpace(cbbxType.Text) ||
          string.IsNullOrWhiteSpace(expenseField.Text) ||
          string.IsNullOrWhiteSpace(txtID.Text) ||
          string.IsNullOrWhiteSpace(incomeField.Text) ||
          string.IsNullOrWhiteSpace(nameField.Text)) {
        return false;
      }
      return true;
    }
