    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl)  // in case you have a combo or something inside it
        {
           // Make your throbber visible
        }
    }
