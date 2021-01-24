    private BindingSource dgvBindingSource1 = null;
    private BindingSource dgvBindingSource2 = null;
    private DataTable dgvDataTable = null;
    private void btnBind_Click(object sender, EventArgs e)
    {
        int maxColumns = 3;
        dgvDataTable = new DataTable("TestTable");
        dgvDataTable.Columns.AddRange(
            Enumerable.Range(0, maxColumns).Select(idx => new DataColumn("Column" + idx.ToString(), typeof(string))).ToArray());
        dgvDataTable.Rows.Add(Enumerable.Range(0, maxColumns).Select(idx => "Value A" + idx.ToString()).ToArray());
        dgvDataTable.Rows.Add(Enumerable.Range(0, maxColumns).Select(idx => "Value B" + idx.ToString()).ToArray());
        dgvDataTable.Rows.Add(Enumerable.Range(0, maxColumns).Select(idx => "Value C" + idx.ToString()).ToArray());
        dgvBindingSource1 = new BindingSource(dgvDataTable, null);
        dgvBindingSource1.RaiseListChangedEvents = true;
        DataView dv = dgvDataTable.AsDataView();
        dv.RowFilter = "Column1 = 'Value A1'";
        dgvBindingSource2 = new BindingSource(dv, null);
        dgvBindingSource2.RaiseListChangedEvents = true;
        dataGridView1.DataSource = dgvBindingSource1;
        dataGridView2.DataSource = dgvBindingSource2;
    }
