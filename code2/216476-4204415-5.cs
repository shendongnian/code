    private bool IsControlVisibleToUser(Control control)
    {
        ListBoxItem listBoxItem =
            listBox.ItemContainerGenerator.ContainerFromItem(control) as ListBoxItem;
        if (listBoxItem != null)
        {
            return IsUserVisible(listBoxItem, listBox);
        }
        return false;
    }
