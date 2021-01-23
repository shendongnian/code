    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CalcDataGridView.CellEndEdit += Calculate;
            var aColumn = new DataGridViewTextBoxColumn();
            aColumn.Name = "AColumn";
            aColumn.HeaderText = "A";
            CalcDataGridView.Columns.Add(aColumn);
            var bColumn = new DataGridViewTextBoxColumn();
            bColumn.Name = "BColumn";
            bColumn.HeaderText = "B";
            CalcDataGridView.Columns.Add(bColumn);
            var totalColumn = new DataGridViewTextBoxColumn();
            totalColumn.Name = "TotalColumn";
            totalColumn.HeaderText = "Total";
            totalColumn.ReadOnly = true;
            CalcDataGridView.Columns.Add(totalColumn);
        }
        private void Calculate(object sender, DataGridViewCellEventArgs e)
        {
            object a = CalcDataGridView.CurrentRow.Cells["AColumn"].Value;
            object b = CalcDataGridView.CurrentRow.Cells["BColumn"].Value;
            double aNumber = 0;
            double bNumber = 0;
            if (a != null)
                aNumber = Double.Parse(a.ToString());
            if (b != null)
                bNumber = Double.Parse(b.ToString());
            CalcDataGridView.CurrentRow.Cells["TotalColumn"].Value = aNumber + bNumber;
        }
    }
