    DataObject data = (DataObject)Clipboard.GetDataObject();
    DataTable dt = (DataTable)data.GetData(DataFormats.Serializable);
    
    foreach (DataRow dr in dt.Rows)
    {
        dtData.ImportRow(dr);
    }
    dtData.AcceptChanges();
    grdProgramData.DataSource = dtData;
    MessageBox.Show("Data Pasted.");
    private void ConvertGridToTable()
    {
    
        if (Datatabledt.Rows.Count > 0)
        { }
    
        Datatabledt = dtData.Clone();
    
        foreach (DataGridViewRow gr in YOURGRIDVIEW.SelectedRows)
        {
            DataRow dc = Datatabledt.NewRow();
            dc["KEY-FIELD"] = Int32.Parse(gr.Cells[0].Value.ToString());
            .....
            ---you can set your conditions here on the basis of textbox value---
            Datatabledt.Rows.Add(dc);
        }
        Datatabledt.AcceptChanges();
    }
