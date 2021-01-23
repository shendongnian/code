        var Transitresults = from root in busStopInfo.Descendants("Placemark")
                     let StoplocationE1 = root.Element("Point").Element("coordinates")
                     let nameE1 = root.Element("name")
                     select new TansitVariables(
                          StoplocationE1 == null ? null : StoplocationE1.Value,
                          nameE1 == null ? null : nameE1.Value);
        listBox2.ItemsSource = Transitresults;
    }
    // Add properties to your class
    public class TransitVariables
    {
            // Add a constructor:
            public TransitVariables(string stopLocation, string name)
            {
                this.StopLocation = stopLocation;
                this.Name = name;
                if (!string.IsNullOrWhiteSpace(stopLocation))
                {
                     var items = stopLocation.Split(',');
                     this.Lon = double.Parse(items[0]);
                     this.Lat = double.Parse(items[1]);
                     this.Alt = double.Parse(items[2]);
                }
            }
            public string StopLocation { get; set; }
            public string Name { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
            public double Alt { get; set; }
    }
