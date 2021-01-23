    private void MenuItem_Click(object sender, RoutedEventArgs e)
            {
                if (sender is MenuItem)
                {
                    IEnumerable<MenuItem> menuItems = null;
                    var mi = (MenuItem)sender;
                    if (mi.Parent is ContextMenu)
                        menuItems = ((ContextMenu)mi.Parent).Items.OfType<MenuItem>();
                    if (mi.Parent is MenuItem)
                        menuItems = ((MenuItem)mi.Parent).Items.OfType<MenuItem>();
                    if(menuItems!=null)
                        foreach (var item in menuItems)
                        {
                            if (item.IsCheckable && item != mi)
                                item.IsChecked = false;
                        }
                }
            }
