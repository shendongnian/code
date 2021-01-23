        TreeViewItem t; 
        private void button2_Click(object sender, RoutedEventArgs e)
        {
           // Delete the node
            Parent.Items.RemoveAt(Parent.Items.IndexOf(t));        
         }
      
        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
      {
            // Get the selected node
            t = (TreeViewItem)(((TreeView)e.Source).SelectedItem);
        }
