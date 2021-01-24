    listView1.Columns.Add("Subject");
    listView1.Columns.Add("Grade");
    listView1.View = View.Details;
    foreach (string item in listBox1.Items)
    {
        var drop = item.Split(',');
        ListViewItem li = new ListViewItem();
        li.Text = drop[0].Trim();
        li.SubItems.Add(drop[1].Trim());
        listView1.Items.Add(li);
    }
