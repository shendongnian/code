    private void _initDataTable() {
      dt = new DataTable();
      dt.Columns.Add(new DataColumn()  {
        DataType = Type.GetType("System.String"), 
        ColumnName = "TestName"
      });
      dt.Columns.Add(new DataColumn()  {
        DataType = Type.GetType("System.Decimal"), 
        ColumnName = "Result"
      });
      dt.Columns.Add(new DataColumn()  {
        DataType = Type.GetType("System.String"), 
        ColumnName = "NonNumericResult"
      });
      dt.Columns.Add(new DataColumn()  {
        DataType = Type.GetType("System.Int32"), 
        ColumnName = "QuickLabDumpid"
      });
    }
