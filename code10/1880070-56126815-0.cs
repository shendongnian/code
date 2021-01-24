    XDocument doc = XDocument.Load("xml.xml");
    XNamespace ns = "http://www.opentravel.org/OTA/2003/05";
    XElement dateRange = doc.Descendants(ns + "DateRange").FirstOrDefault();
    DateTime dateStart = DateTime.Parse(dateRange.Attribute("Start").Value);
    DateTime dateEnd = DateTime.Parse(dateRange.Attribute("End").Value);
    XElement hotelRef = doc.Descendants(ns + "HotelRef").FirstOrDefault();
    int hotelCode = int.Parse(hotelRef.Attribute("HotelCode").Value);
