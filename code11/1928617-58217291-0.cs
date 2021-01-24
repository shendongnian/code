    protected void Edit_Click(object sender, EventArgs e)
        {
            Edit.Enabled = false;
            Set(true);
        }
    
    protected void Save_Click(object sender, EventArgs e)
        {  
            Edit.Enabled = true;
            Set(false);
        }
    
     protected void Cancel_Click(object sender, EventArgs e)
        {
            Edit.Enabled = true;
            Set(false);
        }
    
    private void Set(bool editEnabled)
    {
            Save.Enabled = !editEnabled;
            Cancel.Enabled = !editEnabled;
            TextBox1.Enabled = !editEnabled;
            TextBox2.Enabled = !editEnabled;
            TextBox3.Enabled = !editEnabled;
            TextBox4.Enabled = !editEnabled;
            TextBox5.Enabled = !editEnabled;
    }
