        private void HandleCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var checkBox = e.OriginalSource as CheckBox;
            if (checkBox != null && checkBox.Name == "HeaderCheckBox")
            {
                var groupItem = checkBox.DataContext as GroupItem;
                //// Assuming MyItem is the item level class and MyGroupedProperty 
                //// is the grouped property that you have added to the grouped
                //// description in your CollectionView.
                foreach (MyItem item in groupItem.Items)
                {
                     //// Place your code for the items under that particular group.
                }
            }
        } 
