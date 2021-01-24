            List<string> delimeteredItems = new List<string>();
            foreach (ListViewItem lvi in listView1.CheckedItems)
            {
                string     item= String.Join("#", lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(si=>si.Text));
                delimeteredItems.Add(item);
            }
            System.IO.File.WriteAllLines(@"c:\temp\lines.txt", delimeteredItems);
