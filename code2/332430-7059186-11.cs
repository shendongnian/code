        var appInfoSet = new HashSet<stAppInfo>(new AppInfoComparer());
        foreach (ListViewItem item in listView1.Items)
        {
            var newItem = new stAppInfo { 
                sTitle = item.Text,
                sRelativePath = item.SubItems[1].Text,
                sCmdLine = item.SubItems[2].Text,
                bFindInstalled = (item.SubItems[3].Text.Equals("Sí")) ? true : false,
                sFindTitle = item.SubItems[4].Text,
                sFindVersion = item.SubItems[5].Text,
                bChecked = (item.SubItems[6].Text.Equals("Sí")) ? true : false};
            appInfoSet.Add(newItem);
        }
