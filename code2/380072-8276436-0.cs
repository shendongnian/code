    listView1.SmallImageList = YourImageList;
    ListViewItem lvi = new ListViewItem();
    lvi.SubItems.Add("A");
    lvi.SubItems.Add("B");
    lvi.SubItems.Add("C");
    lvi.ImageIndex = 2; // this will display YourImageList.Images[2] in the first column
    listView1.Items.Add(lvi);
