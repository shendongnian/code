             // ListViewItem lvi = new ListViewItem();
             for (int i = 0; i < titleList.Count; i++)
             {
                ListViewItem lvi = rowNews.Items.Add(titleList[i].InnerXml);
                lvi.SubItems.Add(urlList[i].InnerXml);
             }
             // rowNews.Items.Add(lvi);
