      private void HandleScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ShowVisibleItems(sender);
          
        }
        private void ShowVisibleItems(object sender)
        {
            var scrollViewer = (FrameworkElement)sender;
            foreach (var item in this.ListBox1.Items)
            {
                var listBoxItem = (FrameworkElement)this.ListBox1.ItemContainerGenerator.ContainerFromItem(item);
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(listBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Grid target = (Grid)myDataTemplate.FindName("GridRoot", myContentPresenter);
                if (IsFullyOrPartiallyVisible(listBoxItem, scrollViewer))
                {
                    target.Visibility = Visibility.Visible;
                }
                else
                {
                    target.Visibility = Visibility.Collapsed;
                }
                
            }
        }
        private bool IsFullyOrPartiallyVisible(FrameworkElement element, FrameworkElement container)
        {
            if (element == null || container == null)
                return false;
            if (element.Visibility != Visibility.Visible)
                return false;
            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
        }
