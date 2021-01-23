    var query = listView1.Items
                         .Cast<ListViewItem>()
                         .Select(item => new stAppInfo
                                 {
                                     sTitle = item.Text,
                                     sRelativePath = item.SubItems[1].Text,
                                     bFindInstalled = item.SubItems[3].Text == "Sí",
                                     sFindTitle = item.SubItems[4].Text,
                                     sFindVersion = item.SubItems[5].Text,
                                     bChecked = item.SubItems[6].Text == "Sí"
                                 })
                         .DistinctBy(x => new { x.sTitle, x.sRelativePath });
