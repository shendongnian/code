        private static XmlElement CreateWayPoint(XmlDocument xmlDoc, 
                                                 string radial, 
                                                 string distance,
                                                 string latDegrees,
                                                 string latMinutes,
                                                 string longDegrees,
                                                 string longMinutes)
    {
        var xmlWayPoint = xmlDoc.CreateElement("WayPoint");
        var xmlRadial = xmlDoc.CreateElement("Radial");
        xmlRadial.InnerText = radial;
        xmlWayPoint.AppendChild(xmlRadial);
        var xmlDistance = xmlDoc.CreateElement("Distance");
        xmlDistance.InnerText = distance;
        xmlWayPoint.AppendChild(xmlDistance);
        var xmlLatitude = xmlDoc.CreateElement("Latitude");
        var xmlLatDegrees = xmlDoc.CreateElement("Degrees");
        xmlLatDegrees.InnerText = latDegrees;
        xmlLatitude.AppendChild(xmlLatDegrees);
        var xmlLatMinutes = xmlDoc.CreateElement("Minutes");
        xmlLatMinutes.InnerText = latMinutes;
        xmlLatitude.AppendChild(xmlLatMinutes);
        xmlWayPoint.AppendChild(xmlLatitude);
        var xmlLongitude = xmlDoc.CreateElement("Longitude");
        var xmlLongDegrees = xmlDoc.CreateElement("Degrees");
        xmlLongDegrees.InnerText = longDegrees;
        xmlLongitude.AppendChild(xmlLongDegrees);
        var xmlLongMinutes = xmlDoc.CreateElement("Minutes");
        xmlLongMinutes.InnerText = longMinutes;
        xmlLongitude.AppendChild(xmlLongMinutes);
        xmlWayPoint.AppendChild(xmlLongitude);
        return xmlWayPoint;
    }
