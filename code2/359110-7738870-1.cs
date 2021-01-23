    DataGridView dggg; //Globally Declared
    private void dd()
    {
        var form = (frmMasterInterface)Application.OpenForms["frmMasterInterface"];//Form Name
        if (form == null) return;
        foreach (DataGridView dgv in form.Controls.OfType<DataGridView>())
            if (dgv.Name == "dataGridView1") //name of data grid view
            {
                dggg = dgv;
                dgv.CellMouseClick += Datagirdmouseclick;
            }
    }
    
    private void Datagirdmouseclick(object sender, DataGridViewCellMouseEventArgs e)
    {
    
        Trace.WriteLine(dggg.Rows[e.RowIndex].Cells["sizeRange"].Value);
    }
