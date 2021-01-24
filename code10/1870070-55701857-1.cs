    private void XmlConfigPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        PivotItem item = ((sender as Pivot).SelectedItem) as PivotItem;
        string header = item.Header.ToString();
        Frame frame = item.Content as Frame;
        switch (header)
        {
                case "Layout": frame?.Navigate(typeof(page1)); break;
                case "stub_tab": frame?.Navigate(typeof(page2)); break;
        }
    }
