        foreach (var root in Transitresults)
        {
            var accentBrush = (Brush)Application.Current.Resources["PhoneAccentBrush"];
            var pin = new Pushpin
            {
                Location = new GeoCoordinate
                    {
                        Latitude = root.Lat,
                        Longitude = root.Lon
                    },
                Background = accentBrush,
                Content = root.Name,
                Tag = root
            };
            pin.MouseLeftButtonUp += BusStop_MouseLeftButtonUp;
            BusStopLayer.AddChild(pin, pin.Location);
        }
    }
    void BusStop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var root =  ((FrameworkElement)sender).Tag as BusStop;
        if (root != null)
        {
            // You now have the original object from which the pushpin was created to derive your
            // required response.
        }
    }
