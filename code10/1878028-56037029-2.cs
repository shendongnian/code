    using XY;
    ...
    private HelperClass helper = new HelperClass();
    private void btn_SelectFolder_Click(object sender, EventArgs e)
    {
        lbl_SelectFolderPath.Text = helper.GetFolderPath();
    }
    
