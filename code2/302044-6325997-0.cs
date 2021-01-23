        int handledTimestamp = 0;
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.Timestamp != handledTimestamp)
            {
                System.Diagnostics.Debug.WriteLine("ListView at " + e.Timestamp);
                handledTimestamp = e.Timestamp;
            }
            e.Handled = true;
        }
        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.Timestamp != handledTimestamp)
            {
                System.Diagnostics.Debug.WriteLine("Button at " + e.Timestamp);
                handledTimestamp = e.Timestamp;
            }
            e.Handled = true;
        }
