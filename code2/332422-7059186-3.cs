     stAppInfo[] appInfo = listView1.Items.Cast<ListViewItem>()
         .Distinct(new LambdaComparer<ListViewItem>(
             (x,y)=>x.Name == y.Name && x.SubItems[0].Text == y.SubItems[0].Text))
         .Select(item =>
            new stAppInfo { 
              sTitle = item.Text,
              sRelativePath = item.SubItems[1].Text,
              sCmdLine = item.SubItems[2].Text,
              bFindInstalled = (item.SubItems[3].Text.Equals("Sí")) ? true : false,
              sFindTitle = item.SubItems[4].Text,
              sFindVersion = item.SubItems[5].Text,
              bChecked = (item.SubItems[6].Text.Equals("Sí")) ? true : false })
          .ToArray();
