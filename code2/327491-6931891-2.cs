    private static void DisplayXmlDocument(XmlNode xmlDoc)
    {
        var wayPoints = xmlDoc.SelectNodes("TrafficPattern/WayPoint");
        if (wayPoints == null)
        {
            return;
        }
        foreach (XmlNode node in wayPoints)
        {
            var radial = node.SelectSingleNode("Radial");
            var distance = node.SelectSingleNode("Distance");
            var latitudeDegrees = node.SelectSingleNode("Latitude/Degrees");
            var latitudeMinutes = node.SelectSingleNode("Latitude/Minutes");
            var longitudeDegrees = node.SelectSingleNode("Longitude/Degrees");
            var longitudeMinutes = node.SelectSingleNode("Longitude/Minutes");
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
