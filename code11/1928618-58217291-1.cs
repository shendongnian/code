    protected void Edit_Click(object sender, EventArgs e)
    {
        SetEnabled(true);
    }
    protected void Save_Click(object sender, EventArgs e)
    {  
        SetEnabled(false);
    }
     protected void Cancel_Click(object sender, EventArgs e)
    {
        SetEnabled(false);
    }
    
    private void SetEnabled(bool editEnabled)
    {
        Edit.Enabled = !editEnabled;
        Save.Enabled = editEnabled;
        Cancel.Enabled = !editEnabled;
        TextBox1.Enabled = !editEnabled;
        TextBox2.Enabled = !editEnabled;
        TextBox3.Enabled = !editEnabled;
        TextBox4.Enabled = !editEnabled;
        TextBox5.Enabled = !editEnabled;
    }
