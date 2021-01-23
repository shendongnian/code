    CheckBox cb = new CheckBox();
    cb.CheckedChanged += delegate(object sender, EventArgs e)
    {
        ShowMessageBox();
    };
    
    private void ShowMessageBox()
    {
        MessageBox.Show("hello");
    }
