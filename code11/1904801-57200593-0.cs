private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
{
    ListViewItem lvi = null;
    TextBox tb = sender as TextBox;
    // Get a reference to the parent ListViewItem control
    DependencyObject temp = tb;
    int maxlevel = 0;
    while (!(temp is ListViewItem) && maxlevel < 1000)
    {
        temp = VisualTreeHelper.GetParent(temp);
        maxlevel++;
    }
    lvi = temp as ListViewItem;
    if (lvi != null){
    {
        //Copy over event arg members and raise it
        MouseButtonEventArgs newarg = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, 
                                          e.ChangedButton, e.StylusDevice);
        newarg.RoutedEvent = ListViewItem.MouseDownEvent;
        newarg.Source = sender;
        lvi.RaiseEvent(newarg);
    }
}
It would seem that the author of the codeproject article I linked to is also on gamedev.stackexchange, so credit to [XiaoChuan Yu][1].
  [1]: https://gamedev.stackexchange.com/users/13964/xiaochuan-yu
