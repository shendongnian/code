    private void button1_Click(object sender, EventArgs e) {
        this.Export();
    }
    private void Export() {
        System.Data.DataTable dt = (System.Data.DataTable)this.dgResult.DataSource;
        if ( dt.Rows.Count > 0 ) {
            // initialize save file dialog
            DialogResult rslt = this.svDialog.ShowDialog(this);
            if ( rslt == DialogResult.OK ) {
                string filePath = this.svDialog.FileName;
                // QueueUserWorkItem runs target delegate in separate thread
                ThreadPool.QueueUserWorkItem( (_state)=> this.Export(dt, filePath) );
            }
        }
        else {
            // ... some other code ....
        }
    }
    private void Export(DataTable data, string filePath) {
        Exception thrownException = null;
        try { Business.ExportToExcel.ExcelFromDataTable(dt, filePath); }
        catch( Exception exc ) { thrownException = exc; }
    
        if ( null == thrownException ) { MsgBox("Export completed."); }
        else { MsgBox("Error: " + thrownException.Message); }
    }
    private void MsgBox(string text) {
        if (this.InvokeRequired) {
            Action<string> dlg = this.MsgBox;
            this.Invoke( dlg, text );
        }
        else {
            MessageBox.Show(this, text);
        }
    }
