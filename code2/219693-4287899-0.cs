        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject depObj = e.OriginalSource as DependencyObject;
            while (depObj != null && (!(depObj is GridViewColumnHeader)))
            {
                depObj = VisualTreeHelper.GetParent(depObj);
            }            
            if (depObj is GridViewColumnHeader && e.ChangedButton == MouseButton.Left)
            {
                ((GridViewColumnHeader)depObj).ContextMenu = ContextMenu;
            }
        }
