      private void MoveListBoxItems(ListBox source, ListBox destination)
            {        
                ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
                foreach (var item in sourceItems)
                {
                    destination.Items.Add(item);
                }
                while (source.SelectedItems.Count > 0)
                {
                    source.Items.Remove(source.SelectedItems[0]);
                }
            }
