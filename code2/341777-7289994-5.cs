    void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItems = listView1.SelectedItems.Cast<ListViewItem>();
        var passed = (selectedItems.Select(l => l.Group.Name).Distinct().Count() >= 2);
        if (passed)
        {
            var categoryItem = selectedItems.Where(l => l.Group.Name.ToLower() == "category").Single();
            var priceItem = selectedItems.Where(l => l.Group.Name.ToLower() == "prices").Single();
        }
    }
