    private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
    {
    	if (e.RepositoryItem is DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)
    	{
    		DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
    		rep.ReadOnly = false;
    		rep.MouseUp += rep_MouseUp;
    		e.RepositoryItem = rep;
    	}		
    		
    }
    void rep_MouseUp(object sender, MouseEventArgs e)
    {
    	DevExpress.XtraEditors.TextEdit te = sender as DevExpress.XtraEditors.TextEdit;
    	te.SelectAll();
    }
