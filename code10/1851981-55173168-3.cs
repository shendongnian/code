            private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            Border border = VisualTreeHelper.GetChild(ImageListview, 0) as Border;
            ScrollViewer scrollViewer = border.Child as ScrollViewer;
            scrollViewer.HorizontalScrollMode = ScrollMode.Enabled;
            scrollViewer.ChangeView(scrollViewer.HorizontalOffset + 100, null, null);
            scrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
        }
