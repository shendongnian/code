        foreach (SearchResult entry in result)
        {
            var members = GetGroupMemberList(entry.GetDirectoryEntry());
            foreach(var item in members)
            {
                var itmListItem = new ListViewItem((string)entry.Properties["sAMAccountName"][0]);
                itmListItem.SubItems.Add(item.ToString());
                lvwListView.Items.Add(itmListItem);
            }
            lvwListView.Refresh();
        }
