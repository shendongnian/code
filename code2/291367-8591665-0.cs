    private void Calendar_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (Mouse.Captured is CalendarItem)
        {
            Mouse.Capture(null);
        }
    }
