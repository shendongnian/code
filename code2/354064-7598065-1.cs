    private DataTable _myDataTable = new DataTable();
    public DataTable MyDataTable
    {
      get
      {
       return _myDataTable;
      }
      set
      {
       _myDataTable = value;
       BindingSource bs = new BindingSource();
       bindingSource1.DataSource = value;
       MyDataGridView.DataSource = bs;
    
       // 4) fill your labels somewhere here
       string tablename = value.TableName; 
       foreach (DataColumn col in value.Columns)
         Console.WriteLine("{0}\t{1}", col.ColumnName, col.DataType);
      }
    }
