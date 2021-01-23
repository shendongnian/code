    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem != null)
        {
            Label1.Text = "You selected " + DropDownList1.SelectedItem.Text;
            Session["UploadFolder] = DropoDownList1.SelectedItem.Text;
        }
    }
