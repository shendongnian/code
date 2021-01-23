        private void myTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            foreach (TreeViewItem dataNode in ((TreeViewItem)e.NewValue).Items)
            {
                TraverseChildrenData(dataNode);
            }
        }
        public void TraverseChildrenData(TreeViewItem treeViewItem)
        {
            //do whatever you want to do with child data item here..   
            MessageBox.Show(treeViewItem.Header.ToString());
            
            foreach (TreeViewItem child in treeViewItem.Items)
            {
                TraverseChildrenData(child);
            }
        }
