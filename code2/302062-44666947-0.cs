                var enumerator = node.ContextMenu?.MenuItems?.GetEnumerator();
                while ((bool)enumerator?.MoveNext())
                {
                    var item = (MenuItem)enumerator.Current;
                    if (item.Text == command)
                    {
                        var menuItemCollection = item.MenuItems;
                        menuItemCollection.Remove(item);
                        break;
                    }
                }
