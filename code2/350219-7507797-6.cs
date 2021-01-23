        void busStops_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;
            var busStopInfo = XDocument.Load("Content/BusStops2.xml");
            var Transitresults = from root in busStopInfo.Descendants("Placemark")
                                 let StoplocationE1 = root.Element("Point").Element("coordinates")
                                 let nameE1 = root.Element("name")
                                 select new TransitVariables
                                     (StoplocationE1 == null ? null : StoplocationE1.Value,
                                              nameE1 == null ? null : nameE1.Value);
           // This should bind the itemsource properly
           // Should use Dispatcher actually...see below
           RhysMapItems.ItemsSource = Transitresults.ToList();
        }
