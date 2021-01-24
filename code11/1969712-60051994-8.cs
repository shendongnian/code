    private void btnDelete_Click(object sender, EventArgs e) {
      BudgetItem target;
      foreach (DataGridViewRow row in DtgTable.SelectedRows) {
        target = (BudgetItem)row.DataBoundItem;
        BudgetList.Remove(target);
      }
      DtgTable.DataSource = null;
      DtgTable.DataSource = BudgetList;
    }
