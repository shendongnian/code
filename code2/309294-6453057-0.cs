    private void handleInner(object asd, RoutedEventArgs e)
        {
            InnerControl c = e.OriginalSource as InnerControl;
            if (c != null)
            {
                //do whatever
            }
            e.Handled = false; // do not set handle to true --> bubbles further
        }
    
    private void handleMostOuter(object asd, RoutedEventArgs e)
        {
            InnerControl c = e.OriginalSource as InnerControl;
            if (c != null)
            {
                //do whatever
            }
            e.Handled = true; // set handled = true, it wont bubble further
        }
