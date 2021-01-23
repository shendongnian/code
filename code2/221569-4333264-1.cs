    private void myTreeView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
    	if (myTreeView.HitTest(e.Location).Node == null)
    	{
    		myTreeView.SelectedNode = null;
    	}
    }
