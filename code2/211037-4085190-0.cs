    var blah = new List<List<string>>()
    {
        new List<string>(){ "A1","B1","C1" },
        new List<string>(){ "A2","B2","C2" },
        new List<string>(){ "A3","B3","C3" },
    };
    listView.BeginUpdate();    
    foreach (var row in blah)
    {
        var item = new ListViewItem(listView.Items.Count.ToString());
        item.SubItems.AddRange(row);
        listView.Items.Add(item);
    }
    listView.EndUpdate();
