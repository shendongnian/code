            var listbox = ((ListBox)sender);
            if (listbox.SelectedItem == null)
            {
                if (e.RemovedItems.Count > 0)
                {
                    object itemToReselect = e.RemovedItems[0];
                    if (listbox.Items.Contains(itemToReselect))
                    {
                        listbox.SelectedItem = itemToReselect;
                    }
                }
            }
