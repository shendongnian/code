    public void listItemClickClick(object sender, RoutedEventArgs e) 
        {
            try
            {
                UserFile fil = (UserFile)(sender as ListBoxItem).DataContext;
                MessageBox.Show("to do: download stuff");
                return;
            }
            catch (InvalidCastException)
            {
            }
            try
            {
                dirWeWantSelected = (Directory)(sender as ListBoxItem).DataContext;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("this should never happen");
            }
            selectedDirectoryTreeItem.IsExpanded = true;
            TreeViewItem want = null;
            try
            {
                want = selectedDirectoryTreeItem.ItemContainerGenerator.ContainerFromItem(dirWeWantSelected) as TreeViewItem;
            }
            catch
            {
                MessageBox.Show("weird error");
            }
            if (want != null)
            {
                want.IsSelected = true;
            }
            else
            {
                selectedDirectoryTreeItem.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
            }
        }
        void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (selectedDirectoryTreeItem.ItemContainerGenerator.Status
                == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                selectedDirectoryTreeItem.ItemContainerGenerator.StatusChanged
                    -= ItemContainerGenerator_StatusChanged;
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input,
                    new Action(DelayedAction));
            }
        }
        void DelayedAction()
        {
            selectedDirectoryTreeItem.Items.MoveCurrentToFirst();
            Directory curr;
            do
            {
                curr = (Directory)selectedDirectoryTreeItem.Items.CurrentItem;
                if (curr.id == dirWeWantSelected.id)
                {
                    curr.Selected = true;
                    return;
                }
                selectedDirectoryTreeItem.Items.MoveCurrentToNext();
            }
            while (selectedDirectoryTreeItem.Items.CurrentItem != null);
        }
