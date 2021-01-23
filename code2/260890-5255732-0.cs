    ImageList il = new ImageList();
    il.Images.Add("test1", Image.FromFile(@"c:\Documents\SharpDevelop Projects\learning2\learning2\Koala.jpg"));
    			
    listView1.View = View.LargeIcon;
    listView1.LargeImageList = il;
    listView1.Items.Add("test");
    
    for(int i = 0; i < il.Images.Count; i++)
    {
        ListViewItem lvi = new ListViewItem();
        lvi.ImageIndex = i;
        lvi.Text="koala 1";
        listView1.Items.Add(lvi);
    }
