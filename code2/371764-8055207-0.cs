    protected void btn_Add_Click(object sender, EventArgs e)
    {
        if( lst_allmembers.SelectedItem != null )
        {
            lst_grpmembers.Items.Add(lst_allmembers.SelectedItem.Text);
            lst_allmembers.Items.Remove(lst_allmembers.SelectedItem.Value);
        }
    }
