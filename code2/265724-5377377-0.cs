    //on button click//       
    protected void Button1_Click1(object sender, EventArgs e)
    {
            if (ListBox1.SelectedItem == null) return;
            ListItem item = new ListItem();
            item.Text = ListBox1.SelectedItem.Text;(error comes here)
            ListBox2.Items.Add(item.Text);
            ListBox1.Items.Remove(item.Text);
    }
