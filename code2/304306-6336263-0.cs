    private DataGridView CopyDataGridView(DataGridView dgv_org)
    {
        DataGridView dgv_copy = new DataGridView();
        try
        {
            if (dgv_copy.Columns.Count == 0)
            {
                foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                {
                    dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                }
            }
    
            DataGridViewRow row = new DataGridViewRow();
    
            for (int i = 0; i < dgv_org.Rows.Count; i++)
            {
                row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                dgv_copy.Rows.Add(row);
            }
            dgv_copy.AllowUserToAddRows = false;
            dgv_copy.Refresh();
    
        }
        catch (Exception ex)
        {
            cf.ShowExceptionErrorMsg("Copy DataGridViw", ex);
        }
        return dgv_copy;
    }
