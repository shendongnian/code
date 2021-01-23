            foreach (var group in listView.Groups)
            {
                var listViewItemsToDelete = listView.Items.Cast<ListViewItem>().Where(item => Equals(item.Group, group));
                foreach (var itemToRemove in listViewItemsToDelete)
                {
                    listView.Items.Remove(itemToRemove);
                }
            }
            listView.Groups.Clear();
