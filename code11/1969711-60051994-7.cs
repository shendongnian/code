    private void btnDelete_Click(object sender, EventArgs e) {
      foreach (DataGridViewRow row in DtgTable.SelectedRows) {
        DataRowView dr = (DataRowView)row.DataBoundItem;
        dr.Delete();
      }
      DtgTable.DataSource = null;
      DtgTable.DataSource = BudgetTable;
      }
    }
