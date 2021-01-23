    public static GeocoderLocation Locate(string query)
    {
        WebRequest request = WebRequest.Create("http://maps.google.com/maps?output=kml&q="
            + HttpUtility.UrlEncode(query));
     
        using (WebResponse response = request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                XDocument document = XDocument.Load(new StreamReader(stream));
     
                XNamespace ns = "http://earth.google.com/kml/2.0";
     
                XElement longitudeElement = document.Descendants(ns + "longitude").FirstOrDefault();
                XElement latitudeElement = document.Descendants(ns + "latitude").FirstOrDefault();
     
                if (longitudeElement != null && latitudeElement != null)
                {
                    return new GeocoderLocation
                    {
                        Longitude = Double.Parse(longitudeElement.Value, CultureInfo.InvariantCulture),
                        Latitude = Double.Parse(latitudeElement.Value, CultureInfo.InvariantCulture)
                    };
                }
            }
        }
     
        return null;
    }
