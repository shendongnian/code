    protected void button_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in theCheckBoxList.Items)
        {
            item.Text = item.Selected ? "Checked" : "UnChecked";
        }
    }
