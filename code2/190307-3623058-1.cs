    private void SessionSummary_Load(object sender, EventArgs e)
    {
            summaryDataGridView.DataSource = GetSessions();
            summaryDataGridView.Columns[4].DefaultCellStyle.Format = "N2";
            summaryDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
