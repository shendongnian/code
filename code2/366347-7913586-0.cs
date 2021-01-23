    for (int groupIndex = 0; groupIndex < 3; ++groupIndex) {
       this.listView1.Groups.Add("GroupKey" + groupIndex, "Test" + groupIndex);
       for (int index = 0; index < 5; ++index) {
          ListViewItem item = new ListViewItem("Test " + groupIndex + "/" + index,
                                               this.listView1.Groups[groupIndex]);
          this.listView1.Items.Insert(0, item);
          this.listView1.Groups[groupIndex].Items.Insert(0, item);
        }
     }
     for (int groupIndex = 2; groupIndex >= 0; --groupIndex) {
        for (int index = 0; index < 5; ++index) {
          ListViewItem item = new ListViewItem("Test2 " + groupIndex + "/" + index,
                                               this.listView1.Groups[groupIndex]);
          this.listView1.Items.Insert(0, item);
          this.listView1.Groups[groupIndex].Items.Insert(0, item);
       }
     }
