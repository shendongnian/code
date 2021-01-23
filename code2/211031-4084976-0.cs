    var blah = new List<List<string>>()
    {
        new List<string>(){ "A1","B1","C1" },
        new List<string>(){ "A2","B2","C2" },
        new List<string>(){ "A3","B3","C3" },
    };
    Func<List<string>, int, ListViewItem> createListViewItem = (row, index) =>
    {
        var result = new ListViewItem() { Text = index.ToString() };
        result.SubItems.AddRange(row.ToArray());
        return result;
    };
    listView1.Items.AddRange(blah.Select(createListViewItem).ToArray());
