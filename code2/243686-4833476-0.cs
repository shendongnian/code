    // should be a cache of some sort, WeakReference'd etc, this is NOT reducing memory load (it is adding memory load)
            Dictionary<Int32, ListViewItem> dict = new Dictionary<int, ListViewItem>();
    
            private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
            {
                
                ListViewItem lvi = null;
                if (dict.ContainsKey(e.ItemIndex))
                {
                    
                    Debug.WriteLine(String.Format("from cache:{0}", e.ItemIndex));
                    lvi = dict[e.ItemIndex];
                }
                else
                {
                    Debug.WriteLine(String.Format("created:{0}", e.ItemIndex));
                    lvi = new ListViewItem { Text = String.Format("item:{0}", e.ItemIndex) };
                    lvi.SubItems.Add( new ListViewItem.ListViewSubItem{Text = String.Format("si:{0}", e.ItemIndex)});
                    dict.Add(e.ItemIndex, lvi);
                }
                e.Item = lvi; 
            }
    
            private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
            {
                // you can draw yourself...
                // e.Graphics.DrawString(e.Item.Text, System.Drawing.SystemFonts.DefaultFont, new SolidBrush(Color.Red), 0f, 0f);
                e.DrawText();
            }
