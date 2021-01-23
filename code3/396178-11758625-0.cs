    private void splitContainer_Panel2_ClientSizeChanged(object sender, EventArgs e)
    {
            btnToggle.Checked = !splitContainer.Panel2Collapsed;
    }
    
    private void splitContainer_Panel1_ClientSizeChanged(object sender, EventArgs e)
    {
            btnToggle.Checked = !splitContainer.Panel2Collapsed;
    }
