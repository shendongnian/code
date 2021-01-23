            protected override void OnListVerticalOffsetChanged(ScrollViewer viewer)
        {
            // Trigger when at the end of the viewport
            if (viewer.VerticalOffset >= viewer.ScrollableHeight)
            {
                if (MoreClick != null)
                {
                    MoreClick(this, new RoutedEventArgs());
                }
            }
        }
        private void ListBox1_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            EnsureBoundToScrollViewer();
        }
