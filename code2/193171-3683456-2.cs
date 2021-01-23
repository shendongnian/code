        private void myTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            foreach (XmlElement dataNode in ((XmlElement)e.NewValue).ChildNodes)
            {
                TraverseChildrenData(dataNode);
            }
        }
        public void TraverseChildrenData(XmlElement treeViewItem)
        {
            //do whatever you want to do with child data item here..   
            MessageBox.Show(treeViewItem.Attributes["Header"].Value);
            foreach (XmlElement child in treeViewItem.ChildNodes)
            {
                TraverseChildrenData(child);
            }
        }
