            private static void OnGroupNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (!(d is MenuItem menuItem))
                    return;
    
                var newGroupName = e.NewValue.ToString();
                var oldGroupName = e.OldValue.ToString();
                if (string.IsNullOrEmpty(newGroupName))
                {
                    RemoveCheckboxFromGrouping(menuItem);
                }
                else
                {
                    if (newGroupName != oldGroupName)
                    {
                        if (!string.IsNullOrEmpty(oldGroupName))
                        {
                            RemoveCheckboxFromGrouping(menuItem);
                        }
                        ElementToGroupNames.Add(menuItem, e.NewValue.ToString());
                        menuItem.Checked += MenuItemChecked;
                        menuItem.Unchecked += MenuItemUnchecked; // <-- ADDED
                    }
                }
            }
    
            private static void RemoveCheckboxFromGrouping(MenuItem checkBox)
            {
                ElementToGroupNames.Remove(checkBox);
                checkBox.Checked -= MenuItemChecked;
                checkBox.Unchecked -= MenuItemUnchecked;   // <-- ADDED
            }
