    item.IsSelected = true;
    ScrollViewer scroller = (ScrollViewer)this.FindVisualChildElement(this.uxTree, typeof(ScrollViewer));
    scroller.ScrollToBottom();
    item.BringIntoView();
    private FrameworkElement FindVisualChildElement(DependencyObject element, Type childType)
    {
        int count = VisualTreeHelper.GetChildrenCount(element);
        for (int i = 0; i < count; i++)
        {
            var dependencyObject = VisualTreeHelper.GetChild(element, i);
            var fe = (FrameworkElement)dependencyObject;
            if (fe.GetType() == childType)
            {
                return fe;
            }
            FrameworkElement ret = null;
            if (fe.GetType().Equals(typeof(ScrollViewer)))
            {
                ret = FindVisualChildElement((fe as ScrollViewer).Content as FrameworkElement, childType);
            }
            else
            {
                ret = FindVisualChildElement(fe, childType);
            }
            if (ret != null)
            {
                return ret;
            }
        }
        return null;
    }
