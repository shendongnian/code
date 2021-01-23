        private static void ContextMenuOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var menu = (ContextMenu)sender;
            if (menu.HasItems)
            {
                menu.MinHeight = menu.Items.Count * 25;
            }
            menu.Loaded -= ContextMenuOnLoaded;
        }
