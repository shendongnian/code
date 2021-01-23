        private void InitialiseListView(IList<string> data)
        {
            listView1.Items.Clear();
            m_CheckedItems.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Col1");
            listView1.Columns[0].Width = listView1.Width;
            ListView.ListViewItemCollection collection = new ListView.ListViewItemCollection(listView1);
            ImageList images = new ImageList();
            images.Images.Add(global::MyApplication.Properties.Resources.Checkbox_Unchecked);
            images.Images.Add(global::MyApplication.Properties.Resources.Checkbox_Checked);
            listView1.SmallImageList = images;
            foreach (string str in data)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = 0;
                item.Text = str;
                collection.Add(item);
            }
        }
