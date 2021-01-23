    private static string GetListBoxItemText(ListBox listBox_, object item_)
    {
      var listBoxItem = listBox_.ItemContainerGenerator.ContainerFromItem(item_)
                        as ListBoxItem;
      if (listBoxItem != null)
      {
        var textBlock = FindChild<TextBlock>(listBoxItem);
        if (textBlock != null)
        {
          return textBlock.Text;
        }
      }
      return null;
    }
    GetListBoxItemText(myListbox, myListbox.SelectedItem)
    FindChild<T> is a function to find a child of type T of a DependencyObject
