        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add(4);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Column1.Items.Add("Item 1");
            Column1.Items.Add("item 1");
            Column1.Items.Add("Item 3");
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            if (dataGrid == null) return;
            var rowsWithComboValues = dataGrid.Rows.Cast<DataGridViewRow>().Where(row => row.Cells.Cast<DataGridViewCell>().First().Value != null);
            if (rowsWithComboValues.Any(row => string.Compare(row.Cells[0].Value.ToString(), e.FormattedValue.ToString(), true, CultureInfo.InvariantCulture) == 0))
                e.Cancel = true;
        }
    }
