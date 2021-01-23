    using System.Data;
    using System.Windows.Forms;
    namespace ZZZ
    {
        class Program
        {
            private DataTable _table;
            private readonly DataGridView _view = new DataGridView();
            public void Setup()
            {
                CreateTable();
                _view.CellValueChanged += CellValueChanged;
            }
            private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                _view[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            private void CreateTable()
            {
                _table = new DataTable("Table");
                _table.Columns.Add("A");
                _table.Columns.Add("B");
                _table.Columns.Add("C");
                _table.Columns.Add("D");
                _table.Columns.Add("E");
                _table.Columns.Add("Combined");
            }
            static void Main(string[] args)
            {
                var p = new Program();
                p.Setup();
            }
        }
    }
