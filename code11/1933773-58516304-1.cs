    private bool AllCellsLessThan20() {
      foreach (DataGridViewRow row in dataGridView1.Rows) {
        if (row.Cells[0].Value != null) {
          string sValue = row.Cells["ConditionColumn"].Value.ToString();
          if (int.TryParse(sValue, out int value)) {
            if (value > 20) {
              return false;
            }
          }
        }
      }
      return true;
    }
