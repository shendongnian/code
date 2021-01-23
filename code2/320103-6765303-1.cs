    /// <summary>
    /// Class implementing helpful extensions to ListBox.
    /// </summary>
    public static class ListBoxExtensions
    {
        /// <summary>
        /// Causes the object to scroll into view centered.
        /// </summary>
        /// <param name="listBox">ListBox instance.</param>
        /// <param name="item">Object to scroll.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Deliberately targeting ListBox.")]
        public static void ScrollIntoViewCentered(this ListBox listBox, object item)
        {
            Debug.Assert(!VirtualizingStackPanel.GetIsVirtualizing(listBox),
                "VirtualizingStackPanel.IsVirtualizing must be disabled for ScrollIntoViewCentered to work.");
    
            // Get the container for the specified item
            var container = listBox.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
            if (null != container)
            {
                if (ScrollViewer.GetCanContentScroll(listBox))
                {
                    // Get the parent IScrollInfo
                    var scrollInfo = VisualTreeHelper.GetParent(container) as IScrollInfo;
                    if (null != scrollInfo)
                    {
                        // Need to know orientation, so parent must be a known type
                        var stackPanel = scrollInfo as StackPanel;
                        var virtualizingStackPanel = scrollInfo as VirtualizingStackPanel;
                        Debug.Assert((null != stackPanel) || (null != virtualizingStackPanel),
                            "ItemsPanel must be a StackPanel or VirtualizingStackPanel for ScrollIntoViewCentered to work.");
    
                        // Get the container's index
                        var index = listBox.ItemContainerGenerator.IndexFromContainer(container);
    
                        // Center the item by splitting the extra space
                        if (((null != stackPanel) && (Orientation.Horizontal == stackPanel.Orientation)) ||
                            ((null != virtualizingStackPanel) && (Orientation.Horizontal == virtualizingStackPanel.Orientation)))
                        {
                            scrollInfo.SetHorizontalOffset(index - Math.Floor(scrollInfo.ViewportWidth / 2));
                        }
                        else
                        {
                            scrollInfo.SetVerticalOffset(index - Math.Floor(scrollInfo.ViewportHeight / 2));
                        }
                    }
                }
                else
                {
                    // Get the bounds of the item container
                    var rect = new Rect(new Point(), container.RenderSize);
    
                    // Find constraining parent (either the nearest ScrollContentPresenter or the ListBox itself)
                    FrameworkElement constrainingParent = container;
                    do
                    {
                        constrainingParent = VisualTreeHelper.GetParent(constrainingParent) as FrameworkElement;
                    } while ((null != constrainingParent) &&
                             (listBox != constrainingParent) &&
                             !(constrainingParent is ScrollContentPresenter));
    
                    if (null != constrainingParent)
                    {
                        // Inflate rect to fill the constraining parent
                        rect.Inflate(
                            Math.Max((constrainingParent.ActualWidth - rect.Width) / 2, 0),
                            Math.Max((constrainingParent.ActualHeight - rect.Height) / 2, 0));
                    }
    
                    // Bring the (inflated) bounds into view
                    container.BringIntoView(rect);
                }
            }
        }
    }
