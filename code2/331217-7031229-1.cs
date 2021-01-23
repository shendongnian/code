    protected override void OnUserAddedRow(DataGridViewRowEventArgs e)
    {
        int actualRowIndex = this.Rows.Count - 2; 
        this.Rows[actualRowIndex].Cells["Salary"].Value = "Rs." + <Your SQL Salary>;
        base.OnUserAddedRow(e);
    }
