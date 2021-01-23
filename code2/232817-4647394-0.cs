    ScatterViewItem svi = new ScatterViewItem();
    svi.Background = new SolidColorBrush(Colors.Transparent);
    svi.ShowsActivationEffects = false;
    svi.BorderBrush = System.Windows.Media.Brushes.Transparent;
    RoutedEventHandler loadedEventHandler = null;
    loadedEventHandler = new RoutedEventHandler(delegate
    {
        svi.Loaded -= loadedEventHandler;
        Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc;
        ssc = svi.Template.FindName("shadow", svi) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
        ssc.Visibility = Visibility.Hidden;
    });
    svi.Loaded += loadedEventHandler;
