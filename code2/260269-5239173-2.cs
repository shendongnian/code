        private static void DisplayListInColumn(ListView listView, string[] values, int columnIndex)
        {
            for (int index = 0; index < values.Length; index++)
            {
                while (index >= listView.Items.Count)
                    listView.Items.Add(new ListViewItem());
                ListViewItem listViewItem = listView.Items[index];
                while (listViewItem.SubItems.Count <= columnIndex)
                    listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                listViewItem.SubItems[columnIndex].Text = values[index];
            }
        }
