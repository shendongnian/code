    private static void DisplayXmlDocument(XmlNode xmlDoc)
    {
        var wayPoints = xmlDoc.SelectNodes("TrafficPattern/WayPoint");
        if (wayPoints == null)
        {
            return;
        }
        foreach (XmlNode wayPoint in wayPoints)
        {
            var radial = wayPoint.SelectSingleNode("Radial");
            var distance = wayPoint.SelectSingleNode("Distance");
            var latitudeDegrees = wayPoint.SelectSingleNode("Latitude/Degrees");
            var latitudeMinutes = wayPoint.SelectSingleNode("Latitude/Minutes");
            var longitudeDegrees = wayPoint.SelectSingleNode("Longitude/Degrees");
            var longitudeMinutes = wayPoint.SelectSingleNode("Longitude/Minutes");
            if (radial != null && 
                distance != null && 
                latitudeDegrees != null && 
                latitudeMinutes != null && 
                longitudeDegrees != null && 
                longitudeMinutes != null)
            {
                Console.WriteLine(string.Format("Radial:{0}, 
                                                Distance:{1}, 
                                                Latitude:({2}, {3}),
                                                Longitude:({4}, {5})", 
                                                radial.InnerText, 
                                                distance.InnerText,
                                                latitudeDegrees.InnerText,
                                                latitudeMinutes.InnerText,
                                                longitudeDegrees.InnerText,
                                                longitudeMinutes.InnerText));
            }
        }
    }
