        if (GroupMembers.Count > 0)
        {
            listView1.Items.Clear();
            key2name getname = new key2name();
     
            //If your going to do this here, you will want to clear your Columns
            //listView1.Columns.Clear();
            //However, I would suggest you put this elsewhere, or better yet set at design time.
            listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("LastSeen", -2, HorizontalAlignment.Left);
            foreach (KeyValuePair<string, string> member in GroupMembers)
            {
                //This creates a new 'row' in your listview, and populates the first column
                // with the Key
                ListViewItem lvi = new ListViewItem(member.Key);
                //This populates the second column with the value
                lvi.SubItems.Add(member.Value);
                
                listView1.Items.Add(lvi)
            }
        }
