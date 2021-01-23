    private bool IsControlVisibleToUser(Control control)
    {
        ListBoxItem listBoxItem =
            c_listBox.ItemContainerGenerator.ContainerFromItem(control) as ListBoxItem;
        if (listBoxItem != null)
        {
            return IsUserVisible(listBoxItem, c_listBox);
        }
        return false;
    }
