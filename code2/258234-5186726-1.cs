    cb.CheckedChanged += delegate(object sender, EventArgs e)
    {
        ShowMessageBox(cb.Checked);
    };
    
    private void ShowMessageBox(bool checkedValue)
    {
        MessageBox.Show(string.Format("The box was {0}checked", 
            checkedValue ? "" : "un"));
    }
