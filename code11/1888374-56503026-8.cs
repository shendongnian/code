    private DataTable GetComboTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("DateTime", typeof(DateTime));
      dt.Columns.Add("StringDateTime", typeof(string));
      return dt;
    }
