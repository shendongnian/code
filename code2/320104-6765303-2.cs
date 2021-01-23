    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var firstVisibleItem = GetFirstVisibleItem(listBox1);
            listBox1.Items.Insert(0, "item0");
            listBox1.Items.Insert(0, "item1");
            listBox1.Items.Insert(0, "item2");
            listBox1.Items.Insert(0, "item3");
            listBox1.Items.Insert(0, "item4");
            listBox1.Items.Insert(0, "item5");
            listBox1.Items.Insert(0, "item6");
            if (firstVisibleItem != null)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                    new Action(delegate()
                    {
                        listBox1.ScrollIntoViewTop(firstVisibleItem);
                    }));
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var firstVisibleItem = GetFirstVisibleItem(listBox1);
            listBox1.Items.Insert(0, "item7");
            listBox1.Items.Insert(0, "item8");
            listBox1.Items.Insert(0, "item9");
            listBox1.Items.Insert(0, "item10");
            listBox1.Items.Insert(0, "item11");
            listBox1.Items.Insert(0, "item12");
            listBox1.Items.Insert(0, "item13");
            listBox1.Items.Insert(0, "item14");
            listBox1.Items.Insert(0, "item15");
            if (firstVisibleItem != null)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                    new Action(delegate()
                    {
                        listBox1.ScrollIntoViewTop(firstVisibleItem);
                    }));
            }
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var firstVisibleItem = GetFirstVisibleItem(listBox1);
            listBox1.Items.Insert(0, "item16");
            listBox1.Items.Insert(0, "item17");
            listBox1.Items.Insert(0, "item18");
            listBox1.Items.Insert(0, "item19");
            listBox1.Items.Insert(0, "item20");
            listBox1.Items.Insert(0, "item21");
            listBox1.Items.Insert(0, "item22");
            listBox1.Items.Insert(0, "item23");
            listBox1.Items.Insert(0, "item24");
            if (firstVisibleItem != null)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                    new Action(delegate()
                    {
                        listBox1.ScrollIntoViewTop(firstVisibleItem);
                    }));
            }
        }
        private object GetFirstVisibleItem(ListBox listBox)
        {
            foreach (var item in listBox.Items)
            {
                var itemContainer = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromItem(item);
                if (WPFHelpers.IsObjectVisibleInContainer(itemContainer, listBox) == ControlVisibility.Full)
                {
                    return item;
                }
            }
            return null;
        }
    }
    public enum ControlVisibility
    {
        Hidden,
        Partial,
        Full,
        FullHeightPartialWidth,
        FullWidthPartialHeight
    }
    public class WPFHelpers
    {
        /// <summary>
        /// Checks to see if an object is rendered visible within a parent container
        /// </summary>
        /// <param name="child">UI element of child object</param>
        /// <param name="parent">UI Element of parent object</param>
        /// <returns>ControlVisibility Enum: Hidden, Partial or Visible</returns>
        public static ControlVisibility IsObjectVisibleInContainer(FrameworkElement child, UIElement parent)
        {
            GeneralTransform childTransform = child.TransformToAncestor(parent);
            //Rect childSize = childTransform.TransformBounds(new Rect(new Point(0, 0), child.RenderSize));
            Rect childSize = childTransform.TransformBounds(new Rect(new Point(0, 0), new Point(child.ActualWidth, child.ActualHeight)));
            Rect result = Rect.Intersect(new Rect(new Point(0, 0), parent.RenderSize), childSize);
            if (result == Rect.Empty)
            {
                return ControlVisibility.Hidden;
            }
            if (result.Height == childSize.Height && result.Width == childSize.Width)
            {
                return ControlVisibility.Full;
            }
            if (result.Height == childSize.Height)
            {
                return ControlVisibility.FullHeightPartialWidth;
            }
            if (result.Width == childSize.Width)
            {
                return ControlVisibility.FullWidthPartialHeight;
            }
            return ControlVisibility.Partial;
        }
    }
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
        //[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters",
        //    Justification = "Deliberately targeting ListBox.")]
        public static void ScrollIntoViewTop(this ListBox listBox, object item)
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
                            //scrollInfo.SetHorizontalOffset(index - Math.Floor(scrollInfo.ViewportWidth / 2));
                            scrollInfo.SetHorizontalOffset(index);
                        }
                        else
                        {
                            //scrollInfo.SetVerticalOffset(index - Math.Floor(scrollInfo.ViewportHeight / 2));
                            scrollInfo.SetVerticalOffset(index);
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
