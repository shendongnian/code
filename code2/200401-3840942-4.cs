    public static decimal Sum(this DataTable dt, string columnName) {
      return dt.AsEnumerable().
        Where(row => !row.IsNull(columnName)).
        Sum(row => Convert.ToDecimal(row[columnName]));
    }
