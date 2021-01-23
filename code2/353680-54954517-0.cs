    private void MembersList_MouseUp(object sender, MouseButtonEventArgs e) {
        if (e.ChangedButton == MouseButton.Left) {
            DependencyObject obj = myListBox.ContainerFromElement((Visual)e.OriginalSource);
            if (obj != null) {
                FrameworkElement element = obj as FrameworkElement;
                if (element != null) {
                    ListBoxItem item = element as ListBoxItem;
                    if (item != null && ((MyViewModel)myListBox.DataContext).myListObject.Contains((MyListItem)item.DataContext)) {
                        myListBox.SelectedItem = item.DataContext;
                    }
                }
            }
        }
    }
