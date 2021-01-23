    ListItem new_item = new ListItem(TextBox1.Text);
    if (!ListBox1.Items.Contains(new_item))
        {
        ListBox1.Items.Add(new_item);
        }
    else
        {
        // handle duplicates
        }
