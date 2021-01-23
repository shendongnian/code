    RoutedEventArgs _eventArg;
    private void Button_MouseDoubleClick(object s, RoutedEventArgs e)
    {
        if (!e.Handled) Debug.WriteLine("Button got unhandled doubleclick.");
        //e.Handled = true;
        _eventArg = e;
    }
    private void ListViewItem_MouseDoubleClick(object s, RoutedEventArgs e)
    {
        if (!e.Handled) Debug.WriteLine("ListViewItem got unhandled doubleclick.");
        e.Handled = true;
        if (_eventArg != null)
        {
            var result = _eventArg.Equals(e);
            Debug.WriteLine(result);
        }
    }
