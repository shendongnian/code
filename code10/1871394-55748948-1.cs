    private BindingSource dgvBindingSource1 = null;
    private BindingSource dgvBindingSource2 = null;
    private DataTable dt = null;
    private void btnBind_Click(object sender, EventArgs e)
    {
        FillData(3);
        dgvBindingSource1 = new BindingSource(dt, null);
        DataView dv = dt.AsDataView();
        dv.RowFilter = "Column1 = 'Value A1'";
        dgvBindingSource2 = new BindingSource(dv, null);
        dataGridView1.DataSource = dgvBindingSource1;
        dataGridView2.DataSource = dgvBindingSource2;
    }
    private void FillData(int cols)
    {
        dt = new DataTable("TestTable");
        dt.Columns.AddRange(Enumerable.Range(0, cols)
                  .Select(idx => new DataColumn("Column" + idx.ToString(), typeof(string))).ToArray());
        dt.Rows.Add(Enumerable.Range(0, cols).Select(idx => "Value A" + idx.ToString()).ToArray());
        dt.Rows.Add(Enumerable.Range(0, cols).Select(idx => "Value B" + idx.ToString()).ToArray());
        dt.Rows.Add(Enumerable.Range(0, cols).Select(idx => "Value C" + idx.ToString()).ToArray());
    }
