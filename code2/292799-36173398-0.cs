    In code behind c# : 
    protected void tv_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView tv = (TreeView)sender;
        tv.SelectedNodeStyle.ForeColor = System.Drawing.Color.MidnightBlue;
        tv.SelectedNodeStyle.BackColor = System.Drawing.Color.PowderBlue;
        tv.SelectedNodeStyle.Font.Bold = true;
    }
