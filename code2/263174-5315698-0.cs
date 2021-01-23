    _dataPoints.AddRange(XData.Descendants("ReportItem").Select(element => 
                                          select new DataPoint(){
                                              Asset = element.Attribute("Asset").Value,
                                              ESN = element.Attribute("ESN").Value,
                                              Longitude = element.Attribute("Longitude").Value,
                                              Latitude = element.Attribute("Latitude").Value,
                                              MessageTime = element.Attribute("MessageTime").Value,
                                              MessageTimeZone = element.Attribute("MessageTimeZone").Value,
                                              MessageTimeZoneGMTOffset = element.Attribute("MessageTimeZoneGMTOffset").Value,
                                              MinutesIdle = element.Attribute("MinutesIdle").Value,
                                              Address = element.Attribute("Address").Value,
                                              Name = element.Attribute("Name").Value,
                                              TripDistance = element.Attribute("TripDistance").Value,
                                              TripDistanceUnit = element.Attribute("TripDistanceUnit").Value
                                          }));
