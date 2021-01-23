    protected void btnUpdate_Click(object sender, EventArgs e)
    {    
        string userid = '';
        string FirstName = '';
        foreach (ListItem li in lst_grpmembers.Items)
        {
             userid = li.Value;
             FirstName = li.Text;
        }
    }
