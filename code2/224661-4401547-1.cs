    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "CUSTOM")
            {
                ListBox1.Visible = true;
            }
        }
