    public partial class Form1 : Form
    {
        private readonly DataTable _table = new DataTable("Table");
        public Form1()
        {
            InitializeComponent();
            _table.Columns.Add("Summary");
            _table.Columns.Add("Beta");
            _table.Columns.Add("Delta");
            const int rowPairs = 1;
            for (int i = 0; i <= rowPairs - 1; i++)
            {
                _table.Rows.Add("Summary1", "n/a", 1);
                _table.Rows.Add("Summary2", 1.00, 2);
                _table.Rows.Add("Summary3", null, null);
            }
            for (int row = 0; row < _table.Rows.Count - 1; row += 3)
            {
                string columnOneTotal = CalculateColumnTotal(row, 1);
                string columnTwoTotal = CalculateColumnTotal(row, 2);
                _table.Rows[row + 2][1] = columnOneTotal;
                _table.Rows[row + 2][2] = columnTwoTotal;
            }
            dataGridView1.DataSource = _table;
        }
        private string CalculateColumnTotal(int row, int column)
        {
            int column1Value;
            bool parsed = int.TryParse(_table.Rows[row][column].ToString(), out column1Value);
            if (!parsed) return "n/a";
            int column2Value;
            parsed = int.TryParse(_table.Rows[row + 1][column].ToString(), out column2Value);
            if (!parsed) return "n/a";
            var total = column1Value - column2Value;
            return total.ToString();
        }
    }
