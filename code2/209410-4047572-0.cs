    public static void ReadModeChanged(DependencyObject d,
       DependencyPropertyChangedEventArgs e)
    {
        if ((bool)e.NewValue)
        {
            RegCardSearchForm c = (RegCardSearchForm)d;
            c.btnSearch.Visibility = Visibility.Collapsed;
            c.btnExport.Visibility = Visibility.Collapsed;
            c.cbExportWay.Visibility = Visibility.Collapsed;
        }
    }
