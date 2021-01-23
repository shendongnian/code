    public void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        int selectedRowIndex = int.Parse(e.RowIndex.ToString());
     
        if (this.dgvList.Columns[e.ColumnIndex] == buttonColumn && selectedRowIndex >= 0)
        {
            DataRow dr = DataGridViewHelper.GetDataRow(this.dgvList);
            MessageBox.Show((string)dr["FirstName"]);
        }
    }
