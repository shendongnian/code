    protected void Button1_Click(object sender, EventArgs e)
    {
        string msg = "";
        
        foreach (ListItem li in ListBox_SubModel.Items)
        {
            if (li.Selected == true)
            {
                msg += "<br />" + li.Value + " is selected";
            }
        }
        Label_SubModel.Text = msg;
    }
