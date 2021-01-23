    public class MyDataColumnCollection : 
        KeyedCollection<string, MyDataColumn>
    {
        protected override string GetKeyForItem(MyDataColumn item)
        {
            return item.ColumnName;
        }
    }
    public class MyDataTable : DataTable
    {
        private MyDataColumnCollection _columns = new MyDataColumnCollection();
        public new MyDataColumnCollection Columns
        {
            get { return this._columns; }
        }
    }
    public class MyDataColumn : DataColumn
    {
        public string MyCustomProperty { get; set; }
    }
    static void Main(string[] args)
    {
        MyDataTable t = new MyDataTable();
        MyDataColumn c = new MyDataColumn();
        c.ColumnName = "My Test Column";
        c.MyCustomProperty = "This is really cool!";
        t.Columns.Add(c);
        foreach (MyDataColumn mdc in t.Columns)
        {
            System.Diagnostics.Debug.WriteLine(mdc.MyCustomProperty);
        }
        MyDataColumn testColumn = t.Columns["My Test Column"];
        System.Diagnostics.Debug.WriteLine(testColumn.MyCustomProperty);
    }
