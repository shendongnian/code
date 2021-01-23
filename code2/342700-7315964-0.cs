        private void HandleCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var checkBox = e.OriginalSource as CheckBox;
            var listView = sender as ListView;
            if (checkBox != null && checkBox.Name == "HeaderCheckBox"
                && listView != null)
            {
                var groupItem = checkBox.DataContext as GroupItem;
                var groupedValue = groupItem.Name;
                //// Assuming MyItem is the item level class and MyGroupedProperty 
                //// is the grouped property that you have added to the grouped
                //// description in your CollectionView.
                foreach (MyItem item in listView.Items)
                {
                    if (item.MyGroupedProperty.ToString() == groupedValue)
                    {
                         //// Place your code for the items under that particular group.
                    }
                }
            }
        } 
