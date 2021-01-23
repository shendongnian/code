    AutoHeightHelper helper;
    private void OnFormLoad(object sender, EventArgs e)
    {
        helper = new AutoHeightHelper(gridView1);
        helper.EnableColumnPanelAutoHeight();
    }
    
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        helper.DisableColumnPanelAutoHeight();
    }
