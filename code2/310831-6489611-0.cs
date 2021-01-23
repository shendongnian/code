    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = string.Empty;
    
        foreach (ListItem listitem in CheckBoxList1.Items)
        {
            if (listitem.Selected)
                Label1.Text += listitem.Text + "<br />";
        }
    }
