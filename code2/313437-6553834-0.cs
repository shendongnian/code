     public partial class Form1 : Form
    {
        int rowsCount;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("col1", "Column 1");
            dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
            dataGridView1.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dataGridView1_RowsRemoved);
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rowsCount++;
            CountRows();
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rowsCount--;
            CountRows();
        }
        private void CountRows()
        {
            label1.Text = String.Format("Number of all rows {0}", rowsCount);
        }
    }
