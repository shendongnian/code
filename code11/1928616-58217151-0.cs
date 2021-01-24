    protected void EditSaveCancel_Click(object sender, EventArgs e)
    {
        Edit.Enabled = (sender != Edit);
        Save.Enabled = !Edit.Enabled;
        Cancel.Enabled = !Edit.Enabled;
        TextBox1.Enabled = !Edit.Enabled;
        TextBox2.Enabled = !Edit.Enabled;
        TextBox3.Enabled = !Edit.Enabled;
        TextBox4.Enabled = !Edit.Enabled;
        TextBox5.Enabled = !Edit.Enabled;
    }
