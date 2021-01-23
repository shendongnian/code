        private void AddPushpinButton_Click(object sender, RoutedEventArgs e)
        {
            GeoCoordinate location = new GeoCoordinate() { Latitude = 51.5, Longitude = 0 };
            Pushpin pushpin1 = new Pushpin() { Location = location, Tag = "FindMeLater" };
            map1.Children.Add(pushpin1);
        }
        private void RemovePushpinButton_Click(object sender, RoutedEventArgs e)
        {
            var pushpin = map1.Children.First(p => (p.GetType() == typeof(Pushpin) && ((Pushpin)p).Tag == "FindMeLater"));
            map1.Children.Remove(pushpin);
        }
