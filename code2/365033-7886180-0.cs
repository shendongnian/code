    public void Method1()
    {
        CheckBox checkBox = new CheckBox();
        checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
    }
    
    void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox c = (CheckBox)sender;
        bool resutlt = c.Checked;
    }
