    public partial class WindowForm: Form
        {
            private DataTable dataTable = new DataTable();
           //This will contain all the selected rows.
            private List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
    
            public WindowForm()
            {
                InitializeComponent();
                dataTable .Columns.Add("Column1");
                dataTable .Columns.Add("Column2");
                dataTable .Columns.Add("Column3");
                for (int i = 0; i < 30; i++)
                {
                    dataTable .Rows.Add(i, "Row" + i.ToString(), "Item" + i.ToString());
                }
                dataGridView1.DataSource = dataTable ;
                //This will select full row of a grid
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //This will allow multi selection
                dataGridView1.MultiSelect = true;
    
                dataGridView1.CurrentCellChanged += new EventHandler(dataGridView1_CurrentCellChanged);
                dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            }
    
            void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            {
                PerformSelection(dataGridView1, selectedRows);
            }
    
            void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
            {
                if (selectedRows.Contains(dataGridView1.CurrentRow))
                {
                    selectedRows.Remove(dataGridView1.CurrentRow);
                }
                else
                {
                    selectedRows.Add(dataGridView1.CurrentRow);
                }
                PerformSelection(this.dataGridView1, selectedRows);
    
            }
    
            private void PerformSelection(DataGridView dgv, List<DataGridViewRow> selectedRowsCollection)
            {  
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (selectedRowsCollection.Contains(dgvRow))
                    {
                        dgvRow.Selected = true;
                    }
                    else
                    {
                        dgvRow.Selected = false;
                    }
                }
            }
        }
