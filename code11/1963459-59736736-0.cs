            foreach (ListViewItem item in listView1.Items)
            {
                Value += Environment.NewLine + item.Text;
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    Value += Environment.NewLine + subitem.Text;
                }
            }
and
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int k = 0; k < listView1.Items[i].SubItems.Count; k++)
                {
                    Value += Environment.NewLine + listView1.Items[i].SubItems[k].Text;
                }
            }
