    public partial class Form1 : Form
    {
        DataGridView _calcDataGridView;
        public Form1()
        {
            InitializeComponent();
            _calcDataGridView = new DataGridView();
            this.Controls.Add(_calcDataGridView);
            _calcDataGridView.Dock = DockStyle.Fill;
            _calcDataGridView.Name = "CalcDataGridView";
            _calcDataGridView.CellEndEdit += Calculate;
            var aColumn = new DataGridViewTextBoxColumn();
            aColumn.Name = "AColumn";
            aColumn.HeaderText = "A";
            _calcDataGridView.Columns.Add(aColumn);
            var bColumn = new DataGridViewTextBoxColumn();
            bColumn.Name = "BColumn";
            bColumn.HeaderText = "B";
            _calcDataGridView.Columns.Add(bColumn);
            var totalColumn = new DataGridViewTextBoxColumn();
            totalColumn.Name = "TotalColumn";
            totalColumn.HeaderText = "Total";
            totalColumn.ReadOnly = true;
            _calcDataGridView.Columns.Add(totalColumn);
        }
        private void Calculate(object sender, DataGridViewCellEventArgs e)
        {
            object a = _calcDataGridView.CurrentRow.Cells["AColumn"].Value;
            object b = _calcDataGridView.CurrentRow.Cells["BColumn"].Value;
            double aNumber = 0;
            double bNumber = 0;
            if (a != null)
                aNumber = Double.Parse(a.ToString());
            if (b != null)
                bNumber = Double.Parse(b.ToString());
            _calcDataGridView.CurrentRow.Cells["TotalColumn"].Value = aNumber + bNumber;
        }
    }
