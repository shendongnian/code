    ListView myList = new ListView();
    ListView.View = View.Details; // This enables the typical column view!
    // Now create the columns
    myList.Columns.Add("First Name", -2, HorizontalAlignment.Left);
    myList.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
    myList.Columns.Add("Date of Birth", -2, HorizontalAlignment.Right);
    // Now create the Items
    ListViewItem item = new ListViewItem(first_name.Text);
    item.SubItems.Add(last_name.Text);
    item.SubItems.Add(dob.Text);
    myList.Items.Add(item);
