        int i = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Run() { Text = "Hello " + (i++).ToString() });
            rtb.Blocks.Add(p);
            Dispatcher.BeginInvoke(() =>
            {
                ScrollViewer sv = rtb.Descendents().OfType<ScrollViewer>().FirstOrDefault();
                sv.ScrollToVerticalOffset(sv.ScrollableHeight);
                sv.UpdateLayout();
            });
        }
