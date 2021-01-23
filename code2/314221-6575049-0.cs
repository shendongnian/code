    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        // Based on this xaml
        ////<Binding ElementName="trackingTable" Path="Name" />                 values[0]
        ////<Binding ElementName="trackingsGrid" Path="ItemsSource" />    values[1]
        IEnumerable<TrackingData> tracking = values[1] as IEnumerable<TrackingData>;
        if(tracking == null)
           return values[0] + " (0)"; // Put some reasonable value here?
        return values[0] + " (" + tracking.Where(t => t.Tracking != null).Count() + ")";
    }
