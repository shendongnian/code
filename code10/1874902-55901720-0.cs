        {
            DataTable m_dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                m_dgv.CellValueChanged += CellValueChangedHandler;
                m_dt.Columns.Add("Col_A", typeof(double));
                m_dt.Columns.Add("Col_B", typeof(string));
                m_dt.Rows.Add(new object[] { 1 });
                m_dgv.DataSource = m_dt;
            }
            private void CellValueChangedHandler(Object sender, DataGridViewCellEventArgs e)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCellEventArgs arg = e as DataGridViewCellEventArgs;
                int row = arg.RowIndex;
                int col = arg.ColumnIndex;
                if (row >= 0 && row == dgv.Rows.Count - 2) //new row already added to DGV
                {
                    double temp = (double)dgv.Rows[row - 1].Cells[0].Value;
                    dgv.Rows[row].Cells[0].Value = temp + 1;
                }
            }
        }
