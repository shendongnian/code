    private void _selectTreeViewHelper(object directory) {
        TreeViewItem want = null;
        bool broke = false;  //probably some sort of wait timeout instead, but works for sake of example
        while (true) {
           Dispatcher.Invoke(new Action(delegate {
              want = selectedDirectoryTreeItem.ItemContainerGenerator.ContainerFromItem(directory) as TreeViewItem;
              if (want != null && want.IsLoaded) {
                   want.IsSelected = true;
                   broke = true;
              }
           }));
           if (broke) { break; }
           Thread.Sleep(100); 
        }
    }
