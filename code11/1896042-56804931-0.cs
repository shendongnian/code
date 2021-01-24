    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       if(DropDownList1.SelectedIndex == 0)
       {
           ListView1.Visible = true;
           ListView2.Visible = false;
       }
       else if(DropDownList1.SelectedIndex == 1)
       {
           ListView1.Visible = false;
           ListView2.Visible = true;
       }
    }
