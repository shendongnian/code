    var appInfoSet = new HashSet<stAppInfo>(
        item => listView1.Items.Cast<ListViewItem>().Select(x=> 
          new stAppInfo { 
                sTitle = item.Text,
                sRelativePath = item.SubItems[1].Text,
                sCmdLine = item.SubItems[2].Text,
                bFindInstalled = (item.SubItems[3].Text.Equals("Sí")) ? true : false,
                sFindTitle = item.SubItems[4].Text,
                sFindVersion = item.SubItems[5].Text,
                bChecked = (item.SubItems[6].Text.Equals("Sí")) ? true : false;}),
          new LambdaComparer<stAppInfo>((x, y) =>  x.sTitle == y.sTitle 
                && x.sRelativePath == y.sRelativePath ));
